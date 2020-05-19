using GoryaynovDB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoryaynovDB.Logic
{
    static class TeacherLogic
    {
        static DatabaseContext context = Program.context;
        public static void Create(Teacher model)
        {
            if (model.PassportNumber == 0)
            {
                throw new Exception("Введён некорректный номер паспорта");
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
            if (model.DateOfBirth.CompareTo(new DateTime(1900, 1, 1)) < 0)
            {
                throw new Exception("Введена некорректная дата рождения");
            }
            if (model.DepartmentId == 0)
            {
                throw new Exception("Некорректный Id кафедры");
            }
            context.Teachers.Add(new Teacher
            {
                PassportNumber = model.PassportNumber,
                LastName = model.LastName,
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                DateOfBirth = model.DateOfBirth,
                DepartmentId = model.DepartmentId
            });
            context.SaveChanges();
        }
        public static List<Teacher> Read(Teacher model, int pageSize = Program.pageSize, int currentPage = 0)
        {
            List<Teacher> result = new List<Teacher>();
            if (model.PassportNumber != 0)
            {
                result = context.Teachers
                    .Where(rec => rec.PassportNumber == model.PassportNumber)
                    .Include(teacher => teacher.Department)
                    .Skip(currentPage * pageSize)
                    .Take(pageSize)
                    .ToList();
            }
            else
            {
                result = context.Teachers
                    .Include(teacher => teacher.Department)
                    .Skip(currentPage * pageSize)
                    .Take(pageSize)
                    .ToList();
            }
            return result;
        }
        public static void Update(Teacher model)
        {
            Teacher teacher = context.Teachers.FirstOrDefault(rec => rec.PassportNumber == model.PassportNumber);
            teacher.LastName = model.LastName;
            teacher.FirstName = model.FirstName;
            teacher.MiddleName = model.MiddleName;
            teacher.DateOfBirth = model.DateOfBirth;
            teacher.DepartmentId = model.DepartmentId;
            context.SaveChanges();
        }
        public static void Delete(Teacher model)
        {
            Teacher teacher = context.Teachers.FirstOrDefault(rec => rec.PassportNumber == model.PassportNumber);
            context.Teachers.Remove(teacher);
            context.SaveChanges();
        }
    }
}
