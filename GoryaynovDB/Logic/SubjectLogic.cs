using GoryaynovDB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoryaynovDB.Logic
{
    static class SubjectLogic
    {
        static DatabaseContext context = Program.context;
        public static void Create(Subject model)
        {
            if (model.Name == null)
            {
                throw new Exception("Введите название предмета");
            }
            if (model.Hours > 0)
            {
                throw new Exception("Неверное кол-во часов");
            }
            context.Subjects.Add(new Subject
            {
                Name = model.Name,
                Hours = model.Hours
            });
            context.SaveChanges();
        }
        public static List<Subject> Read(Subject model, int pageSize = Program.pageSize, int currentPage = 0)
        {
            List<Subject> result = new List<Subject>();
            if (model.Name != null)
            {
                result = context.Subjects
                    .Where(rec => rec.Name.Equals(model.Name))
                    .Skip(pageSize * currentPage)
                    .Take(pageSize)
                    .ToList();
            }
            else
            {
                result = context.Subjects
                    .Skip(pageSize * currentPage)
                    .Take(pageSize)
                    .ToList();
            }
            return result;
        }
        public static void Update(Subject model)
        {
            Subject subject = context.Subjects.FirstOrDefault(rec => rec.Name.Equals(model.Name));
            subject.Name = model.Name;
            subject.Hours = model.Hours;
            context.SaveChanges();
        }
        public static void Delete(Subject model)
        {
            Subject subject = context.Subjects.FirstOrDefault(rec => rec.Name.Equals(model.Name));
            context.Subjects.Remove(subject);
            context.SaveChanges();
        }
    }
}
