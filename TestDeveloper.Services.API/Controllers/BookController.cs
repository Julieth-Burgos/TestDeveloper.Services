using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDeveloper.Services.API.Extensions;
using TestDeveloper.Services.Domain.Entities;
using TestDeveloper.Services.Infraestructure.Interfaces;

namespace TestDeveloper.Services.API.Controllers
{
    [Route("api/v1/Book")]
    [ApiController]
    public class BookController : Controller
    {
        #region Properties

        /// <summary>
        /// Instancia de acceso al repositorio de datos de la entidad Book
        /// </summary>
        private readonly IBookRepository bookRepository;

        /// <summary>
        /// Instancia de acceso al repositorio de datos de la entidad Author
        /// </summary>
        private readonly IAuthorRepository authorRepository;

        #endregion

        #region Constructor

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="BookController"/> .
        /// </summary>
        /// <param name="bookRepository">Instancia de acceso al repositorio de datos de la entidad Book.</param>
        public BookController(IBookRepository bookRepository, IAuthorRepository authorRepository)
        {
            this.bookRepository = bookRepository;
            this.authorRepository = authorRepository;
        }

        #endregion

        #region GetBookList

        [HttpGet("GetBookList")]
        public IActionResult GetBookList()
        {
            try
            {
                List<Book> data = this.bookRepository.GetBookList();
                return this.StatusCode(200, data.ContertToStructure());
            }
            catch (Exception error)
            {
                return this.StatusCode(500, error);
            }
        }

        #endregion

        #region GetBookById

        /// <summary>
        /// Servicio que obtiene la información específica de un libro por ID
        /// </summary>
        /// <param name="bookId">El identificador del libro</param>
        /// <returns>Una lista de tipo Book</returns>
        [HttpGet("GetBookById")]
        public IActionResult GetBookById(int bookId)
        {
            try
            {
                Book book = this.bookRepository.GetBookById(bookId);

                if (book == null)
                {
                    return this.StatusCode(500, $"El libro con el identificador {bookId} no existe o no esta registrado.");
                }

                return this.Ok(book);
            }
            catch (Exception error)
            {
                return this.StatusCode(500, error);
            }
        }

        #endregion

        #region AddBook

        /// <summary>
        /// Servicio que agrega la información de un nuevo libro
        /// </summary>
        /// <param name="book">Un objeto con la información del nuevo libro</param>
        /// <returns></returns>
        [HttpPost("AddBook")]
        public IActionResult AddBook(Book book)
        {
            try
            {
                Book data = this.bookRepository.GetBookByTitle(book.Title);

                if (data != null)
                {
                    return this.StatusCode(500, "El libro ya existe!");
                }

                List<Book> books = this.bookRepository.GetBookList();

                if (books.Count > 0 && books.Count >= int.Parse(Resources.NumberBooksAllowed))
                {
                    return this.StatusCode(500, "No es posible registrar el libro, se alcanzó el máximo permitido");
                }

                Author author = this.authorRepository.GetAuthorById(book.AuthorId);

                if (author == null)
                {
                    return this.StatusCode(500, "El autor no está registrado");
                }

                if (!this.bookRepository.AddBook(book))
                {
                    return this.StatusCode(500, "¡No se pudo registrar la información del libro!");
                }

                return this.Ok("¡El libro se ha registrado exitosamente!");
            }
            catch (Exception error)
            {
                return this.StatusCode(500, error);
            }
        }

        #endregion

        #region UpdateBook

        /// <summary>
        /// Servicio que actualiza la información de un libro específico
        /// </summary>
        /// <param name="book">Un objeto con la información del libro</param>
        /// <returns></returns>
        [HttpPut("UpdateBook")]
        public IActionResult UpdateBook(Book book)
        {
            try
            {
                Book data = this.bookRepository.GetBookById(book.BookId);

                if (data == null)
                {
                    return this.StatusCode(500, $"El libro con el identificador {book.BookId} no existe o no esta registrado.");
                }

                Book dataByTitle = this.bookRepository.GetBookByTitle(book.Title);

                if (dataByTitle != null && dataByTitle.BookId != book.BookId)
                {
                    return this.StatusCode(500, "El libro ya existe!");
                }

                if (!this.bookRepository.UpdateBook(book))
                {
                    return this.StatusCode(500, "¡No se pudo actualizar la información del libro!");
                }

                return this.Ok("¡La información del libro se ha actualizado exitosamente!");
            }
            catch (Exception error)
            {
                return this.StatusCode(500, error);
            }
        }

        #endregion

        #region DeleteBook

        /// <summary>
        /// Servicio que elimina la información de un libro específico por ID
        /// </summary>
        /// <param name="bookId">El identificador del libro</param>
        /// <returns></returns>
        [HttpDelete("DeleteBook")]
        public IActionResult DeleteBook(int bookId)
        {
            try
            {
                Book data = this.bookRepository.GetBookById(bookId);

                if (data == null)
                {
                    return this.StatusCode(500, $"El libro con el identificador {bookId} no existe o no esta registrado.");
                }

                if (!this.bookRepository.DeleteBook(data))
                {
                    return this.StatusCode(500, "¡No se pudo eliminar la información del libro!");
                }

                return this.Ok("¡El libro se ha eliminado exitosamente!");
            }
            catch (Exception error)
            {
                return this.StatusCode(500, error);
            }
        }

        #endregion
    }
}
