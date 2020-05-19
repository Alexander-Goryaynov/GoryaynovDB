using GoryaynovDB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GoryaynovDB
{
    class DatabaseContext : DbContext
    {
        const string CONFIG_FILE_ADDRESS = "config.txt";
        public DbSet<Department> Departments { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DatabaseContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(GetConnectionString());
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasSequence<int>("seq_department").StartsAt(1001).IncrementsBy(1);
            modelBuilder.HasSequence<int>("seq_groups").StartsAt(2001).IncrementsBy(1);
            modelBuilder.HasSequence<int>("seq_rate").StartsAt(3001).IncrementsBy(1);
            modelBuilder.HasSequence<int>("seq_subject").StartsAt(4001).IncrementsBy(1);
            modelBuilder.Entity<Department>().Property(it => it.Id).UseHiLo("seq_department");
            modelBuilder.Entity<Group>().Property(it => it.Id).UseHiLo("seq_groups");
            modelBuilder.Entity<Rate>().Property(it => it.Id).UseHiLo("seq_rate");
            modelBuilder.Entity<Subject>().Property(it => it.Id).UseHiLo("seq_subject");
        }
        string GetConnectionString()
        {
            if (!CheckConfigFile(CONFIG_FILE_ADDRESS))
            {
                throw new Exception("Неверный формат файла конфигурации");
            }            
            string[] data = new string[4];
            using(StreamReader sr = new StreamReader(CONFIG_FILE_ADDRESS, Encoding.GetEncoding(1251)))
            {
                int i = 0;
                string str = "";
                while ((str = sr.ReadLine()) != null)
                {
                    data[i] = str.Split(" ")[1];
                    Console.WriteLine(data[i]);
                    i++;
                }                
            }
            Console.WriteLine();
            return $"Host={data[0]};Port={data[1]};Username={data[2]};Database={data[3]};";
        }
        bool CheckConfigFile(string fileAddress)
        {
            int count = 0;
            using(StreamReader sr = new StreamReader(fileAddress))
            {
                while (sr.ReadLine() != null) 
                {
                    count++;
                }
            }
            return (count == 4) ? true : false;
        }        
    }
}
