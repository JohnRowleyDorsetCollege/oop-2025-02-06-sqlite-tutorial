// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Tutorial.Domain;
using Tutorial.Domain.Repository;

Console.WriteLine("SQL Lite Tutorial");

SQLitePCL.Batteries_V2.Init();

var options = new DbContextOptionsBuilder<AppDbContext>()
           .UseSqlite("Data Source=c:/sqlite/oop-tutorial-2025-02-06.db")
           .Options;

var context = new AppDbContext(options);
var studentRepository = new StudentRepository(context);
studentRepository.DeleteAllStudents();

var student1 = new Student() { Name = "Peter", Age = 18 };
var student2 = new Student() { Name = "Paul", Age = 56 };

//Console.WriteLine(student1.Name);

//context.Students.Add(student1);
//context.Students.Add(student2);

studentRepository.AddStudent(student1);
studentRepository.AddStudent(student2);


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


      //   using var context = new AppDbContext();
        using var unitOfWork = new UnitOfWork(context);

        // Add a new movie
        var newMovie = new Movie { Title = "Inception", Year = 2010, Genre = "Sci-Fi" };
        await unitOfWork.Movies.AddAsync(newMovie);
        
        // Add a new book
        var newBook = new Book { Title = "1984", Author = "George Orwell" };
        await unitOfWork.Books.AddAsync(newBook);

        // Save changes
        await unitOfWork.SaveChangesAsync();

        // Retrieve all movies
        var moviesx = await unitOfWork.Movies.GetAllAsync();
        Console.WriteLine("Movies in the database:");
        foreach (var movie in moviesx)
        {
            Console.WriteLine($"- {movie.Title} ({movie.Year}) - {movie.Genre}");
        }

        // Retrieve all books
        var booksx = await unitOfWork.Books.GetAllAsync();
        Console.WriteLine("\nBooks in the database:");
        foreach (var book in booksx)
        {
            Console.WriteLine($"- {book.Title} by {book.Author}");
        }
 