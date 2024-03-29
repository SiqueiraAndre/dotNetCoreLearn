﻿using BookAPI.Model;
using BookAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookrepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookrepository = bookRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _bookrepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            return await _bookrepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> PostBook([FromBody] Book book)
        {
            var newBook = await _bookrepository.Create(book);
            return CreatedAtAction(nameof(GetBook), new { id = newBook.Id }, newBook);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Book>> Delete(int id)
        {
            var bookToDelete = await _bookrepository.Get(id);

            if (bookToDelete == null)
                return NotFound();

            await _bookrepository.Delete(bookToDelete.Id);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult<Book>> PutBooks(int id, [FromBody] Book book)
        {
            if (id != book.Id)
                return BadRequest();

                await _bookrepository.Update(book);

            return NoContent();
        }
    }
}
