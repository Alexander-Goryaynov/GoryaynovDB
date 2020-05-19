using GoryaynovDB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoryaynovDB.Logic
{
    static class StudentLogic
    {
        static DatabaseContext context = Program.context;
        public static void Create(Student model)
        {
            if (model.RecordBookNumber == 0)
            {
                throw new Exception("Введён некорректный номер зачётной книжки");
            }
            if (model.LastName == null)
            {
                throw new Exception("Введите фамилию");
            }
            if (model.FirstName == null)
            {
                throw new Exception("Введите имя");
            }
            if (model.MiddleName == null)
            {
                throw new Exception("Введите отчество");
            }
            if (model.Gender == null)
            {
                throw new Exception("Введите пол");
            }
            if (model.DateOfBirth.CompareTo(new DateTime(1900, 1, 1)) < 0)
            {
                throw new Exception("Введена некорректная дата рождения");
            }
            if (model.GroupId == 0)
            {
                throw new Exception("Некорректный Id группы");
            }
            context.Students.Add(new Student
            {
                RecordBookNumber = model.RecordBookNumber,
                LastName = model.LastName,
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                DateOfBirth = model.DateOfBirth,
                Gender = model.Gender,
                GroupId = model.GroupId
            });
            context.SaveChanges();
        }
        public static List<Student> Read(Student model, int pageSize = Program.pageSize, int currentPage = 0)
        {
            List<Student> result = new List<Student>();
            if (model.RecordBookNumber != 0)
            {
                result = context.Students
                    .Where(rec => rec.RecordBookNumber == model.RecordBookNumber)
                    .Include(student => student.Group)
                    .Skip(currentPage * pageSize)
                    .Take(pageSize)
                    .ToList();
            }
            else
            {
                result = context.Students
                    .Include(student => student.Group)
                    .Skip(currentPage * pageSize)
                    .Take(pageSize)
                    .ToList();
            }
            return result;
        }
        public static void Update(Student model)
        {
            Student student = context.Students.FirstOrDefault(rec => rec.RecordBookNumber == model.RecordBookNumber);
            student.LastName = model.LastName;
            student.FirstName = model.FirstName;
            student.MiddleName = model.MiddleName;
            student.Gender = model.Gender;
            student.DateOfBirth = model.DateOfBirth;
            student.GroupId = model.GroupId;
            context.SaveChanges();
        }
        public static void Delete(Student model)
        {
            Student student = context.Students.FirstOrDefault(rec => rec.RecordBookNumber == model.RecordBookNumber);
            context.Students.Remove(student);
            context.SaveChanges();
        }
    }
}
