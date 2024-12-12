using Bookstore.Communication.Response;
using Bookstore.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Controllers;

public class BookController : BookstoreBaseController
{
    [HttpGet]
    [ProducesResponseType(typeof(List<Book>), StatusCodes.Status200OK)]
    public IActionResult GetAllBooks()
    {
        return Ok(ManagerDataBaseJson.GetBooks()); 
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResponseCreateBookJson), StatusCodes.Status201Created)]
    public IActionResult CreateBook([FromBody] Book book)
    {
        ManagerDataBaseJson.AddBook(book);
        
        var response = new ResponseCreateBookJson(book.Id, book.Title);
        
        return Created(string.Empty, response);
    }

    [HttpPut]
    [Route("{idBook}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult EditBook([FromRoute] int idBook, [FromBody] Book book)
    {
        ManagerDataBaseJson.EditBook(idBook, book);
        return NoContent();
    }

    [HttpDelete]
    [Route("{idBook}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult DeleteBook([FromRoute] int idBook)
    {
        ManagerDataBaseJson.DelteBook(idBook);
        return NoContent();
    }
}
