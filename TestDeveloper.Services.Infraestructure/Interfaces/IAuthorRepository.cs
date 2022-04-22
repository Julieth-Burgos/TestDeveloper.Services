using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDeveloper.Services.Domain.Entities;

namespace TestDeveloper.Services.Infraestructure.Interfaces
{
    public interface IAuthorRepository
    {
        /// <summary>
        /// Retorna la información de la tabla Authors
        /// </summary>
        /// <returns>Objeto de tipo Lista</returns>
        List<Author> GetAuthorList();

        /// <summary>
        /// Obtiene la información de un autor específico por su ID
        /// </summary>
        /// <param name="authorId">El identificador del registro o autor</param>
        /// <returns>Un objeto de tipo Author</returns>
        Author GetAuthorById(int authorId);

        /// <summary>
        /// Obtiene la información de un autor específico por su nombre
        /// </summary>
        /// <param name="name">El nombre del autor</param>
        /// <returns>Un objeto de tipo Author</returns>
        Author GetAuthorByName(string name);

        /// <summary>
        /// Agrega la información de un nuevo autor
        /// </summary>
        /// <param name="data">Un objeto con la información del autor</param>
        /// <return><c>True</c> si realiza la inserción del registro de forma exitosa</return>
        bool AddAuthor(Author data);

        /// <summary>
        /// Actualiza la información de un autor específico
        /// </summary>
        /// <param name="data">Un objeto con la información del autor</param>
        /// <return><c>True</c> si realiza la actualización del registro de forma exitosa</return>
        bool UpdateAuthor(Author data);

        /// <summary>
        /// Elimina la información de un autor especifico
        /// </summary>
        /// <param name="data">Un objeto con la información del autor</param>
        /// <returns><c>True</c> si realiza la eliminación del registro de forma exitosa</returns>
        bool DeleteAuthor(Author data);
    }
}
