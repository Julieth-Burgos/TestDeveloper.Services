using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TestDeveloper.Service.Infraestructure.DBContext;
using TestDeveloper.Services.Domain.Entities;
using TestDeveloper.Services.Infraestructure.Interfaces;

namespace TestDeveloper.Services.Infraestructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        #region Properties

        /// <summary>
        /// Representa la información del contexto de la base de datos
        /// </summary>
        private readonly ModelContext modelContext;

        #endregion

        #region Constructor

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref = "BookRepository" />.
        /// </summary>
        public BookRepository()
        {
            this.modelContext = new ModelContext(DBContext.ConnectionStringName.DBConnection.ToString().GetConnection<ModelContext>());
        }

        #endregion

        #region GetBookList

        /// <summary>
        /// Retorna la información de la tabla Books
        /// </summary>
        /// <returns>Objeto de tipo Lista</returns>
        public List<Book> GetBookList()
        {
            //return modelContext.Book.ToList();
            return modelContext.Book.Include(x => x.Author).ToList().Select(item => new Book
            {
                BookId = item.BookId,
                Title = item.Title,
                Year = item.Year,
                NumberPages = item.NumberPages,
                AuthorId = item.AuthorId,
                Name = item.Author.Name/**/
            }).ToList();
        }

        #endregion

        #region GetBookById

        /// <summary>
        /// Obtiene la información de un libro específico por su ID
        /// </summary>
        /// <param name="bookId">El identificador del registro o libro</param>
        /// <returns>Un objeto de tipo Book</returns>
        public Book GetBookById(int bookId)
        {
            return modelContext.Book.ToList().Where(x => x.BookId == bookId).FirstOrDefault();
        }

        #endregion

        #region GetBookByTitle

        /// <summary>
        /// Obtiene la información de un libro específico por su nombre
        /// </summary>
        /// <param name="title">El nombre del libro</param>
        /// <returns>Un objeto de tipo Book</returns>
        public Book GetBookByTitle(string title)
        {
            return modelContext.Book.ToList().Where(x => x.Title == title).FirstOrDefault();
        }

        #endregion

        #region AddBook

        /// <summary>
        /// Agrega la información de un nuevo libro
        /// </summary>
        /// <param name="data">Un objeto con la información del libro</param>
        /// <return><c>True</c> si realiza la inserción del registro de forma exitosa</return>
        public bool AddBook(Book data)
        {
            this.modelContext.Book.Add(data);

            try
            {
                this.modelContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                ex.Entries.Single().Reload();
                return false;
            }

            return true;
        }

        #endregion

        #region UpdateBook

        /// <summary>
        /// Actualiza la información de un libro específico
        /// </summary>
        /// <param name="data">Un objeto con la información del libro</param>
        /// <return><c>True</c> si realiza la actualización del registro de forma exitosa</return>
        public bool UpdateBook(Book data)
        {
            try
            {
                Book dataSearch = modelContext.Book.ToList().Where(x => x.BookId == data.BookId).FirstOrDefault();

                if (dataSearch != null)
                {
                    EntityEntry entry = modelContext.Entry(dataSearch);
                    entry.CurrentValues.SetValues(data);
                    entry.OriginalValues.SetValues(dataSearch);
                }

                this.modelContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                ex.Entries.Single().Reload();
                return false;
            }

            return true;
        }

        #endregion

        #region DeleteBook

        /// <summary>
        /// Elimina la información de un libro especifico
        /// </summary>
        /// <param name="data">Un objeto con la información del libro</param>
        /// <returns><c>True</c> si realiza la eliminación del registro de forma exitosa</returns>
        public bool DeleteBook(Book data)
        {
            if (data != null)
            {
                if (this.modelContext.Entry(data).State == EntityState.Detached)
                {
                    this.modelContext.Book.Attach(data);
                }

                this.modelContext.Book.Remove(data);
                this.modelContext.SaveChanges();
                return true;
            }

            return false;
        }

        #endregion
    }
}
