using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDeveloper.Services.Domain.Entities;

namespace TestDeveloper.Services.Infraestructure.Interfaces
{
    public interface IBookRepository
    {
        /// <summary>
        /// Retorna la información de la tabla Books
        /// </summary>
        /// <returns>Objeto de tipo Lista</returns>
        List<Book> GetBookList();

        /// <summary>
        /// Obtiene la información de un libro específico por su ID
        /// </summary>
        /// <param name="bookId">El identificador del registro o libro</param>
        /// <returns>Un objeto de tipo Author</returns>
        Book GetBookById(int bookId);

        /// <summary>
        /// Obtiene la información de un libro específico por su nombre
        /// </summary>
        /// <param name="name">El nombre del libro</param>
        /// <returns>Un objeto de tipo Book</returns>
        Book GetBookByTitle(string name);

        /// <summary>
        /// Agrega la información de un nuevo libro
        /// </summary>
        /// <param name="data">Un objeto con la información del libro</param>
        /// <return><c>True</c> si realiza la inserción del registro de forma exitosa</return>
        bool AddBook(Book data);

        /// <summary>
        /// Actualiza la información de un libro específico
        /// </summary>
        /// <param name="data">Un objeto con la información del libro</param>
        /// <return><c>True</c> si realiza la actualización del registro de forma exitosa</return>
        bool UpdateBook(Book data);

        /// <summary>
        /// Elimina la información de un libro especifico
        /// </summary>
        /// <param name="data">Un objeto con la información del libro</param>
        /// <returns><c>True</c> si realiza la eliminación del registro de forma exitosa</returns>
        bool DeleteBook(Book data);
    }
}
