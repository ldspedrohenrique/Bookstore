namespace Bookstore.Communication.Response;

public class ResponseCreateBookJson
{
    public int BookId { get; set; }
    public string BookName { get; set; }

    public ResponseCreateBookJson(int bookId, string bookName)
    {
        BookId = bookId;
        BookName = bookName;
    }
}