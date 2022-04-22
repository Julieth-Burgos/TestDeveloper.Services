using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDeveloper.Services.Domain.Entities
{
    /// <summary>
    /// Representa la información del objeto Libros
    /// </summary>
    [Table("Books")]
    public class Book
    {
        /// <summary>
        /// Obtiene o establece el identificador único del registro
        /// </summary>
        [Key]
        public int BookId { get; set; }

        /// <summary>
        /// Obtiene o establece el título del libro
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Obtiene o establece el año de publicación del libro
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Obtiene o establece el número de páginas del libro
        /// </summary>
        public int NumberPages { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del autor del libro
        /// </summary>
        public int AuthorId { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del autor del libro
        /// </summary>
        [NotMapped]
        public string Name { get; set; }/**/

        /// <summary>
        /// Obtiene un objeto con las propiedades de la tabla relacionada Author
        /// </summary>
        public Author Author { get; set; }
    }
}
