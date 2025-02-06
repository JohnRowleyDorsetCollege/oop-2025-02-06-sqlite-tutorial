// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Tutorial.Domain;

Console.WriteLine("SQL Lite Tutorial");

SQLitePCL.Batteries_V2.Init();

var options = new DbContextOptionsBuilder<AppDbContext>()
           .UseSqlite("Data Source=c:/sqlite/students20250205a.db")
           .Options;

var student1 = new Student() { Id = 1, Name = "John", Age = 18 };
var student2 = new Student() { Id = 1, Name = "John", Age = 18 };

Console.WriteLine(student1.Name); // False