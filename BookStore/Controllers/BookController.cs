﻿using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : Controller
    {
        private static List<Book> BookList = new List<Book>()
        {
            new Book
            {
                Id = 1,
                Title ="The Midnight Library",
                GenreId = 1, // novel
                PageCount = 283,
                PublishDate = new DateTime(2022,08,13)
            },
            new Book
            {
                Id = 2,
                Title ="The Brain",
                GenreId = 2, // science
                PageCount = 272,
                PublishDate = new DateTime(2014,10,14)
            },
            new Book
            {
                Id = 3,
                Title ="Dune",
                GenreId = 3, // fiction
                PageCount = 712,
                PublishDate = new DateTime(2021,08,09)
            }
        };

        [HttpGet]
        public List<Book> GetBooks()
        {
            var bookList = BookList.OrderBy(x => x.Id).ToList<Book>();
            return bookList;
        }

        [HttpGet("{id}")]
        public Book GetById(int id)
        {
            var book = BookList.Where(x => x.Id == id).SingleOrDefault();
            return book;
        }

        //[HttpGet]
        //public Book Get([FromQuery] string id)
        //{
        //    var book = BookList.Where(x => x.Id == Convert.ToInt32(id)).SingleOrDefault();
        //    return book;
        //}
    }
}