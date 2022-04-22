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
    public class AuthorRepository : IAuthorRepository
    {
        #region Properties

        /// <summary>
        /// Representa la información del contexto de la base de datos
        /// </summary>
        private readonly ModelContext modelContext;

        #endregion

        #region Constructor

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref = "AuthorRepository" />.
        /// </summary>
        public AuthorRepository()
        {
            this.modelContext = new ModelContext(DBContext.ConnectionStringName.DBConnection.ToString().GetConnection<ModelContext>());
        }

        #endregion

        #region GetAuthorList

        /// <summary>
        /// Retorna la información de la tabla Authors
        /// </summary>
        /// <returns>Objeto de tipo Lista</returns>
        public List<Author> GetAuthorList()
        {
            return modelContext.Author.ToList();
        }

        #endregion

        #region GetAuthorById

        /// <summary>
        /// Obtiene la información de un autor específico por su ID
        /// </summary>
        /// <param name="authorId">El identificador del registro o autpr</param>
        /// <returns>Un objeto de tipo Author</returns>
        public Author GetAuthorById(int authorId)
        {
            return modelContext.Author.ToList().Where(x => x.AuthorId == authorId).FirstOrDefault();
        }

        #endregion

        #region GetAuthorByName

        /// <summary>
        /// Obtiene la información de un autor específico por su nombre
        /// </summary>
        /// <param name="name">El nombre del autor</param>
        /// <returns>Un objeto de tipo Author</returns>
        public Author GetAuthorByName(string name)
        {
            return modelContext.Author.ToList().Where(x => x.Name == name).FirstOrDefault();
        }

        #endregion

        #region AddAuthor

        /// <summary>
        /// Agrega la información de un nuevo autor
        /// </summary>
        /// <param name="data">Un objeto con la información del autor</param>
        /// <return><c>True</c> si realiza la inserción del registro de forma exitosa</return>
        public bool AddAuthor(Author data)
        {
            this.modelContext.Author.Add(data);

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

        #region UpdateAuthor

        /// <summary>
        /// Actualiza la información de un autor específico
        /// </summary>
        /// <param name="data">Un objeto con la información del autor</param>
        /// <return><c>True</c> si realiza la actualización del registro de forma exitosa</return>
        public bool UpdateAuthor(Author data)
        {
            try
            {
                Author dataSearch = modelContext.Author.ToList().Where(x => x.AuthorId == data.AuthorId).FirstOrDefault();

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

        #region DeleteAuthor

        /// <summary>
        /// Elimina la información de un autor especifico
        /// </summary>
        /// <param name="data">Un objeto con la información del autor</param>
        /// <returns><c>True</c> si realiza la eliminación del registro de forma exitosa</returns>
        public bool DeleteAuthor(Author data)
        {
            if (data != null)
            {
                if (this.modelContext.Entry(data).State == EntityState.Detached)
                {
                    this.modelContext.Author.Attach(data);
                }

                this.modelContext.Author.Remove(data);
                this.modelContext.SaveChanges();
                return true;
            }

            return false;
        }

        #endregion
    }
}
