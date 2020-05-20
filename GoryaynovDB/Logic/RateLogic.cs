using GoryaynovDB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoryaynovDB.Logic
{
    static class RateLogic
    {
        static DatabaseContext context = Program.context;
        public static void Create(Rate model)
        {
            if (model.Mark == 0)
            {
                throw new Exception("Введите оценку");
            }
            if (model.Date.CompareTo(new DateTime(1900, 1, 1)) < 0)
            {
                throw new Exception("Введите дату");
            }
            if (model.SubjectId == 0)
            {
                throw new Exception("Некорректный Id предмета");
            }
            if (model.StudentRecordBookNumber == 0)
            {
                throw new Exception("Некорректный номер зачётки студента");
            }
            if (model.TeacherPassportNumber == null)
            {
                throw new Exception("Некорректный номер паспорта преподавателя");
            }
            context.Rates.Add(new Rate
            {
                Mark = model.Mark,
                Date = model.Date,
                SubjectId = model.SubjectId,
                TeacherPassportNumber = model.TeacherPassportNumber,
                StudentRecordBookNumber = model.StudentRecordBookNumber
            });
            context.SaveChanges();
        }
        public static List<Rate> Read(Rate model, int pageSize = Program.pageSize, int currentPage = 0)
        {
            List<Rate> result = new List<Rate>();
            if (model.Id != 0)
            {
                result = context.Rates
                    .Where(rec => rec.Id == model.Id)
                    .Include(rate => rate.Student)
                    .Include(rate => rate.Teacher)
                    .Include(rate => rate.Subject)
                    .Skip(currentPage * pageSize)
                    .Take(pageSize)
                    .ToList();
            } 
            else
            {
                result = context.Rates
                    .Include(rate => rate.Student)
                    .Include(rate => rate.Teacher)
                    .Include(rate => rate.Subject)
                    .Skip(currentPage * pageSize)
                    .Take(pageSize)
                    .ToList();
            }
            return result;
        }
        public static void Update(Rate model)
        {
            Rate rate = context.Rates.FirstOrDefault(rec => rec.Id == model.Id);
            rate.Mark = model.Mark;
            rate.Date = model.Date;
            rate.SubjectId = model.SubjectId;
            rate.StudentRecordBookNumber = model.StudentRecordBookNumber;
            rate.TeacherPassportNumber = model.TeacherPassportNumber;
            context.SaveChanges();
        }
        public static void Delete(Rate model)
        {
            Rate rate = context.Rates.FirstOrDefault(rec => rec.Id == model.Id);
            context.Rates.Remove(rate);
            context.SaveChanges();
        }
    }
}
