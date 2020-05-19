using GoryaynovDB.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoryaynovDB.Logic
{
    static class GroupLogic
    {
        static DatabaseContext context = Program.context;
        public static void Create(Group model)
        {
            if (model.Name == null)
            {
                throw new Exception("Введите имя группы");
            }
            if ((model.Year > 10) || (model.Year < 1))
            {
                throw new Exception("Курс указан некорректно");
            }
            if (model.PrefectLastName == null)
            {
                throw new Exception("Введите фамилию старосты");
            }
            context.Groups.Add(new Group
            {
                Name = model.Name,
                Year = model.Year,
                PrefectLastName = model.PrefectLastName
            });
            context.SaveChanges();
        }
        public static List<Group> Read(Group model, int pageSize = Program.pageSize, int currentPage = 0)
        {
            List<Group> result = new List<Group>();
            if (model.Name != null)
            {
                result = context.Groups
                    .Where(rec => rec.Name.Equals(model.Name))
                    .Skip(pageSize * currentPage)
                    .Take(pageSize)
                    .ToList();
            }
            else
            {
                result = context.Groups
                    .Skip(pageSize * currentPage)
                    .Take(pageSize)
                    .ToList();
            }
            return result;
        }
        public static void Update(Group model)
        {
            Group group = context.Groups.FirstOrDefault(rec => rec.Name.Equals(model.Name));
            group.Name = model.Name;
            group.PrefectLastName = model.PrefectLastName;
            group.Year = model.Year;
            context.SaveChanges();
        }
        public static void Delete(Group model)
        {
            Group group = context.Groups.FirstOrDefault(rec => rec.Name.Equals(model.Name));
            context.Groups.Remove(group);
            context.SaveChanges();
        }
    }
}
