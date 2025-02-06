// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Tutorial.Domain;

Console.WriteLine("SQL Lite Tutorial");

SQLitePCL.Batteries_V2.Init();

var options = new DbContextOptionsBuilder<AppDbContext>()
           .UseSqlite("Data Source=c:/sqlite/oop-tutorial-2025-02-06.db")
           .Options;

var context = new AppDbContext(options);


var student1 = new Student() { Name = "Peter", Age = 18 };
var student2 = new Student() { Name = "Paul", Age = 56 };

Console.WriteLine(student1.Name); // False

context.Students.Add(student1); 
context.Students.Add(student2);
await context.SaveChangesAsync();

foreach(var student in context.Students)
{
    Console.WriteLine($"Student: {student.Name} {student.Age}");
}