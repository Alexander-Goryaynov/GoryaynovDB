using GoryaynovDB.Logic;
using GoryaynovDB.Models;
using System;
using System.Linq;
using System.Text;

namespace GoryaynovDB
{
    class Program
    {
        public static DatabaseContext context = null;
        public const int pageSize = 100;
        static void Main(string[] args) 
        { 
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            try
            {
                context = new DatabaseContext();
                Console.WriteLine(CreateDepartment());
                Console.WriteLine(CreateGroup());
                Console.WriteLine(CreateRate());
                Console.WriteLine(ReadStudents());
                Console.WriteLine(ReadTeachers());
                Console.WriteLine(ReadSubjects());
                Console.WriteLine(UpdateDepartment());
                Console.WriteLine(UpdateGroup());
                Console.WriteLine(UpdateSubject());
                Console.WriteLine(DeleteDepartment());
                Console.WriteLine(DeleteSubject());
                Console.WriteLine(DeleteTeacher());
                Console.WriteLine(RunFirstLabScript());
                Console.WriteLine(RunSecondLabScript());
                Console.WriteLine(RunThirdLabScript());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                Environment.Exit(-1);
            }            
        }
        static double CreateDepartment()
        {
            var department = new Department
            {
                Name = "Экономика",
                CuratorLastName = "Медведева"
            };
            var startTime = DateTime.Now;
            DepartmentLogic.Create(department);
            var finishTime = DateTime.Now;
            Console.WriteLine("---Скрипт CreateDepartment выполнен");
            return (int)(finishTime - startTime).TotalMilliseconds;
        }
        static double CreateGroup()
        {
            var group = new Group
            {
                Name = "УЖКХбд-11",
                Year = 1,
                PrefectLastName = "Кузнецов"
            };
            var startTime = DateTime.Now;
            GroupLogic.Create(group);
            var finishTime = DateTime.Now;
            Console.WriteLine("---Скрипт CreateGroup выполнен");
            return (finishTime - startTime).TotalMilliseconds;
        }
        static double CreateRate()
        {
            var rate = new Rate
            {
                Mark = 3,
                Date = DateTime.Now,
                SubjectId = context.Subjects
                    .FirstOrDefault(rec => rec.Name.Equals("Физика")).Id,
                StudentRecordBookNumber = context.Students
                    .FirstOrDefault(rec => rec.LastName.Equals("Яровая")).RecordBookNumber,
                TeacherPassportNumber = context.Teachers
                    .FirstOrDefault(rec => rec.LastName.Equals("Лазарев")).PassportNumber
            };
            var startTime = DateTime.Now;
            RateLogic.Create(rate);
            var finishTime = DateTime.Now;
            Console.WriteLine("---Скрипт CreateRate выполнен");
            return (finishTime - startTime).TotalMilliseconds;
        }
        static double ReadSubjects()
        {
            var subject = new Subject
            {
                Name = "Газодинамика"
            };
            var startTime = DateTime.Now;
            var subjects = SubjectLogic.Read(subject);
            var finishTime = DateTime.Now;
            foreach (var s in subjects)
            {
                Console.WriteLine(s.Name + " " + s.Hours);
            }                
            Console.WriteLine("---Скрипт ReadSubjects выполнен");
            return (finishTime - startTime).TotalMilliseconds;
        }
        static double ReadStudents()
        {
            var student = new Student { RecordBookNumber = 38567 };
            var startTime = DateTime.Now;
            var students = StudentLogic.Read(student);
            var finishTime = DateTime.Now;
            foreach (var s in students)
            {
                Console.WriteLine(s.LastName + " " + s.FirstName + " " + s.Group.Name);
            }
            Console.WriteLine("---Скрипт ReadStudents выполнен");
            return (finishTime - startTime).TotalMilliseconds;
        }
        static double ReadTeachers()
        {
            var teacher = new Teacher
            {
                PassportNumber = null
            };
            var startTime = DateTime.Now;
            var teachers = TeacherLogic.Read(teacher);
            var finishTime = DateTime.Now;
            foreach(var t in teachers)
            {
                Console.WriteLine($"{t.FirstName}  {t.MiddleName}  {t.LastName}");
            }
            Console.WriteLine("---Скрипт ReadTeachers выполнен");
            return (finishTime - startTime).TotalMilliseconds;
        }
        static double UpdateGroup()
        {
            var groupToUpd = GroupLogic
                .Read(new Group { Name = "РТбд-32" })
                .FirstOrDefault();
            var newGroup = new Group
            {
                Id = groupToUpd.Id,
                Name = groupToUpd.Name,
                PrefectLastName = "Чернов",
                Year = groupToUpd.Year
            };
            var startTime = DateTime.Now;
            GroupLogic.Update(newGroup);
            var finishTime = DateTime.Now;
            Console.WriteLine("---Скрипт UpdateGroup выполнен");
            return (finishTime - startTime).TotalMilliseconds;
        }
        static double UpdateSubject()
        {
            var subjectToUpd = SubjectLogic
                .Read(new Subject { Name = "Газодинамика" })
                .FirstOrDefault();
            var newSubject = new Subject
            {
                Id = subjectToUpd.Id,
                Name = subjectToUpd.Name,
                Hours = 130
            };
            var startTime = DateTime.Now;
            SubjectLogic.Update(newSubject);
            var finishTime = DateTime.Now;
            Console.WriteLine("---Скрипт UpdateSubject выполнен");
            return (finishTime - startTime).TotalMilliseconds;
        }
        static double UpdateDepartment()
        {
            var departmentToUpd = DepartmentLogic
                .Read(new Department { Name = "Радиотехника" })
                .FirstOrDefault();
            var newDepartment = new Department
            {
                Id = departmentToUpd.Id,
                Name = departmentToUpd.Name,
                CuratorLastName = "Воронин"
            };
            var startTime = DateTime.Now;
            DepartmentLogic.Update(newDepartment);
            var finishTime = DateTime.Now;
            Console.WriteLine("---Скрипт UpdateDepartment выполнен");
            return (finishTime - startTime).TotalMilliseconds;
        }
        static double DeleteSubject()
        {
            var subject = new Subject { Name = "Газодинамика" };
            var startTime = DateTime.Now;
            SubjectLogic.Delete(subject);
            var finishTime = DateTime.Now;
            Console.WriteLine("---Скрипт DeleteSubject выполнен");
            return (finishTime - startTime).TotalMilliseconds;
        }
        static double DeleteTeacher()
        {
            var teacher = new Teacher { PassportNumber = "7332089703" };
            var startTime = DateTime.Now;
            TeacherLogic.Delete(teacher);
            var finishTime = DateTime.Now;
            Console.WriteLine("---Скрипт DeleteTeacher выполнен");
            return (finishTime - startTime).TotalMilliseconds;
        }
        static double DeleteDepartment()
        {
            var department = new Department { Name = "Электропривод"};
            var startTime = DateTime.Now;
            DepartmentLogic.Delete(department);
            var finishTime = DateTime.Now;
            Console.WriteLine("---Скрипт DeleteDepartment выполнен");
            return (finishTime - startTime).TotalMilliseconds;
        }
        static double RunFirstLabScript()
        {
            // вывести номер зачётки, ФИО студента, группу и курс
            var startTime = DateTime.Now;
            var students = StudentLogic.Read(new Student { RecordBookNumber = 0 });
            var finishTime = DateTime.Now;
            foreach (var s in students)
            {
                Console.WriteLine($"{s.RecordBookNumber} {s.LastName} {s.FirstName} " +
                    $"{s.MiddleName} {s.Group.Name} {s.Group.Year}");
            }
            Console.WriteLine("---Скрипт FirstLabScript выполнен");
            return (finishTime - startTime).TotalMilliseconds;
        }
        static double RunSecondLabScript()
        {
            // вывести число преподавателей по кафедрам
            var startTime = DateTime.Now;
            var teacherGroups = TeacherLogic
                .Read(new Teacher { PassportNumber = null })
                .Join(context.Departments,
                    t => t.DepartmentId,
                    d => d.Id, 
                    (t, d) => new
                    {
                        TeacherPassportNumber = t.PassportNumber,
                        DepartmentName = d.Name
                    })
                .GroupBy(rec => rec.DepartmentName)
                .ToList();
            var finishTime = DateTime.Now;
            foreach (var group in teacherGroups)
            {
                Console.WriteLine(group.Key + " " + group.Count());
            }
            Console.WriteLine("---Скрипт SecondLabScript выполнен");
            return (finishTime - startTime).TotalMilliseconds;
        }
        static double RunThirdLabScript()
        {
            // отобразить оценки, полученные Яровой за последние 100 дней
            var startTime = DateTime.Now;
            var rates = RateLogic.Read(new Rate { Id = 0 })
                .Where(rec => rec.Student.LastName.Equals("Яровая"))
                .Where(rec => rec.Date > DateTime.Now.AddDays(-100));
            var finishTime = DateTime.Now;
            foreach (var r in rates)
            {
                Console.WriteLine($"{r.Mark} {r.Date.ToShortDateString()} {r.Subject.Name}");
            }
            Console.WriteLine("---Скрипт ThirdLabScript выполнен");
            return (finishTime - startTime).TotalMilliseconds;
        }
    }
}
