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
    /// Representa la información del objeto Autor
    /// </summary>
    [Table("Authors")]
    public class Author
    {
        /// <summary>
        /// Obtiene o establece el identificador único del registro
        /// </summary>
        [Key]
        public int AuthorId { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del autor del libro
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha de nacimiento del autor
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// Obtiene o establece la ciudad de procedencia del autor
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Obtiene o establece el correo electrónico del autor
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Representa una colección de tipo Book
        /// </summary>
        public ICollection<Book> Book { get; set; }/**/
    }
}
