using GoryaynovDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoryaynovDB.Logic
{
    static class DepartmentLogic
    {
        static DatabaseContext context = Program.context;
        public static void Create(Department model)
        {
            if (model.Name == null)
            {
                throw new Exception("Введите название кафедры");
            }
            if (model.CuratorLastName == null)
            {
                throw new Exception("Введите фамилию заведующего кафедрой");
            }
            context.Departments.Add(new Department
            {
                Name = model.Name,
                CuratorLastName = model.CuratorLastName
            });
            context.SaveChanges();
        }
        public static List<Department> Read(Department model, int pageSize = Program.pageSize, int currentPage = 0)
        {
            List<Department> result = new List<Department>();
            if (model.Name != null)
            {
                result = context.Departments
                    .Where(rec => rec.Name.Equals(model.Name))
                    .Skip(pageSize * currentPage)
                    .Take(pageSize)
                    .ToList();
            }
            else
            {
                result = context.Departments
                    .Skip(pageSize * currentPage)
                    .Take(pageSize)
                    .ToList();
            }
            return result;
        }
        public static void Update(Department model)
        {
            Department department = context.Departments.FirstOrDefault(rec => rec.Name.Equals(model.Name));
            department.Name = model.Name;
            department.CuratorLastName = model.CuratorLastName;
            context.SaveChanges();
        }
        public static void Delete(Department model)
        {
            Department department = context.Departments.FirstOrDefault(rec => rec.Name.Equals(model.Name));
            context.Departments.Remove(department);
            context.SaveChanges();
        }
    }
}
