﻿using System;
using GoodBooks.Data;
using GoodBooks.Services;
using GoodBooks.Web.RequestMethods;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GoodBooks.Web.Controllers
{
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;
        private readonly IBookService _bookService;

        public BooksController(ILogger<BooksController> logger, IBookService bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }

        [HttpGet("/api/books")]
        public ActionResult GetBooks()
        {
            var books = _bookService.GetAllBooks();
            return Ok(books);
        }
        
        [HttpGet("/api/books/{id}")]
        public ActionResult GetBooks(int id)
        {
            var books = _bookService.GetBook(id);
            return Ok(books);
        }
        
        
        [HttpPost("/api/books")]
        public ActionResult CreateBooks([FromBody] NewBookRequest bookRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model state not valid.");
            }
            
            var now = DateTime.UtcNow;
            var book = new Book
            {
                CreatedOn = now,
                UpdatedOn = now,
                Title = bookRequest.Title,
                Author = bookRequest.Author,
                    
            };
            
            _bookService.AddBook(book);
            return Ok($"Book Created: {book.Title}");
        }
        
          
        [HttpDelete("/api/books/{id}")]
        public ActionResult DeleteBook(int id)
        {
             _bookService.DeleteBook(id);
            return Ok($"Book Deleted with id: {id}");
        }
    }
}
