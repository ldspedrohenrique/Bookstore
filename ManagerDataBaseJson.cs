using System.Text.Json;
using Bookstore.Entities;

namespace Bookstore;

public static class ManagerDataBaseJson
{
    
    private static string Path = "data.json";

    private static JsonSerializerOptions Options = new JsonSerializerOptions
    {
        WriteIndented = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    private static List<Book> RemoveBookfromList(int idBook, List<Book> books)
    {
        for (int i = 0; i < books.Count; i++)
        {
            if (idBook == books[i].Id)
            {
                books.RemoveAt(i);
            }
        }
        
        return books;
    }

    private static Book? GetBookById(int id)
    {
        var books = ReadFileDataJson();
        
        foreach (var book in books)
        {
            if (book.Id == id)
            {
                return book;
            }
        }
        
        return null;
    }

    private static void WriteFileDataJson(string booksJson)
    {
        File.WriteAllText(Path, booksJson);
    }
    
    private static List<Book> ReadFileDataJson()
    {
        return JsonSerializer.Deserialize<List<Book>>(File.ReadAllText(Path), Options);
    }

    public static List<Book> GetBooks()
    {
        return ReadFileDataJson();
    }
    
    public static void AddBook(Book book)
    {
        var books = ReadFileDataJson();
        books.Add(book);
        
        WriteFileDataJson(JsonSerializer.Serialize(books, Options));
    }

    public static void EditBook(int idBook, Book editBook)
    {
        DelteBook(idBook);
        
        AddBook(editBook);
    }
    
    public static void DelteBook(int idBook)
    {
        var books = ReadFileDataJson();
        
        books = RemoveBookfromList(idBook, books);

        WriteFileDataJson(JsonSerializer.Serialize(books, Options));
    }
}