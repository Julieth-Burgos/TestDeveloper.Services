using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDeveloper.Services.Domain.Entities;
using TestDeveloper.Services.Infraestructure.Interfaces;

namespace TestDeveloper.Services.API.Controllers
{
    [Route("api/v1/Author")]
    [ApiController]
    public class AuthorController : Controller
    {
        #region Properties

        /// <summary>
        /// Instancia de acceso al repositorio de datos de la entidad Author
        /// </summary>
        private readonly IAuthorRepository authorRepository;

        #endregion

        #region Constructor

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="AuthorController"/> .
        /// </summary>
        /// <param name="authorRepository">Instancia de acceso al repositorio de datos de la entidad EvertecWalletActionsTypes.</param>
        public AuthorController(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }

        #endregion

        #region GetAuthorList

        [HttpGet("GetAuthorList")]
        public IActionResult GetAuthorList()
        {
            try
            {
                List<Author> data = this.authorRepository.GetAuthorList();
                return this.Ok(data);
            }
            catch (Exception error)
            {
                return this.StatusCode(500, error);
            }
        }

        #endregion

        #region GetAuthorById

        /// <summary>
        /// Servicio que obtiene la información específica de un autor por ID
        /// </summary>
        /// <param name="authorId">El identificador del autor</param>
        /// <returns>Una lista de tipo Author</returns>
        [HttpGet("GetAuthorById")]
        public IActionResult GetAuthorById(int authorId)
        {
            try
            {
                Author author = this.authorRepository.GetAuthorById(authorId);

                if (author == null)
                {
                    return this.StatusCode(500, $"El autor con el identificador {authorId} no existe o no esta registrado.");
                }

                return this.Ok(author);
            }
            catch (Exception error)
            {
                return this.StatusCode(500, error);
            }
        }

        #endregion

        #region AddAuthor

        /// <summary>
        /// Servicio que agrega la información de un nuevo autor
        /// </summary>
        /// <param name="author">Un objeto con la información del nuevo autor</param>
        /// <returns></returns>
        [HttpPost("AddAuthor")]
        public IActionResult AddAuthor(Author author)
        {
            try
            {
                Author data = this.authorRepository.GetAuthorByName(author.Name);

                if (data != null)
                {
                    return this.StatusCode(500, "El autor ya existe!");
                }

                if (!this.authorRepository.AddAuthor(author))
                {
                    return this.StatusCode(500, "¡No se pudo registrar la información del autor!");
                }

                return this.Ok("¡El autor se ha registrado exitosamente!");
            }
            catch (Exception error)
            {
                return this.StatusCode(500, error);
            }
        }

        #endregion

        #region UpdateAuthor

        /// <summary>
        /// Servicio que actualiza la información de un autor específico
        /// </summary>
        /// <param name="author">Un objeto con la información del autor</param>
        /// <returns></returns>
        [HttpPut("UpdateAuthor")]
        public IActionResult UpdateAuthor(Author author)
        {
            try
            {
                Author data = this.authorRepository.GetAuthorById(author.AuthorId);

                if (data == null)
                {
                    return this.StatusCode(500, $"El autor con el identificador {author.AuthorId} no existe o no esta registrado.");
                }

                if (!this.authorRepository.UpdateAuthor(author))
                {
                    return this.StatusCode(500, "¡No se pudo actualizar la información del autor!");
                }

                return this.Ok("¡La información del autor se ha actualizado exitosamente!");
            }
            catch (Exception error)
            {
                return this.StatusCode(500, error);
            }
        }

        #endregion

        #region DeleteAuthor

        /// <summary>
        /// Servicio que elimina la información de un autor específico por ID
        /// </summary>
        /// <param name="authorId">El identificador del autor</param>
        /// <returns></returns>
        [HttpDelete("DeleteAuthor")]
        public IActionResult DeleteAuthor(int authorId)
        {
            try
            {
                Author data = this.authorRepository.GetAuthorById(authorId);

                if (data == null)
                {
                    return this.StatusCode(500, $"El autor con el identificador {authorId} no existe o no esta registrado.");
                }

                if (!this.authorRepository.DeleteAuthor(data))
                {
                    return this.StatusCode(500, "¡No se pudo eliminar la información del autor!");
                }

                return this.Ok("¡El autor se ha eliminado exitosamente!");
            }
            catch (Exception error)
            {
                return this.StatusCode(500, error);
            }
        }

        #endregion
    }
}
