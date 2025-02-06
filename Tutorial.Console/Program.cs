﻿// See https://aka.ms/new-console-template for more information
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

List<Movie> movies = new List<Movie>
{
    new Movie { Title = "The Matrix", Genre = "Sci-Fi", Year = 1999 },
    new Movie { Title = "The Matrix Reloaded", Genre = "Sci-Fi", Year = 2003 },
    new Movie { Title = "The Matrix Revolutions", Genre = "Sci-Fi", Year = 2003 }
};

List<Book> books = new List<Book> { new Book { Title = "The Matrix", Author = "Foo" } };

context.Movies.AddRange(movies);
context.Books.AddRange(books);


await context.SaveChangesAsync();

foreach (var student in context.Students)
{
    Console.WriteLine($"Student: {student.Name} {student.Age}");
}

foreach (var movie in context.Movies)
{
    Console.WriteLine($"Movie: {movie.Title} {movie.Genre} {movie.Year}");
}

foreach (var book in context.Books)
{
    Console.WriteLine($"book: {book.Title} {book.Author} ");
}