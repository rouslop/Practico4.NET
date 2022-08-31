using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace DataAccessLayer.Models
{
    public class Personas
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id_Persona { get; set; }
        [MaxLength(128), MinLength(3), Required]
        public string Nombre { get; set; }
        [MaxLength(10), MinLength(2), Required]
        public string Documento { get; set; }

        public Persona ToEntity()
        {
            return new Persona()
            {
                Id = Id_Persona,
                Documento = Documento,
                Nombre = Nombre
            };
        }
        public static Personas ToSave(Persona x)
        {
            return new Personas()
            {
                Id_Persona = (int)x.Id,
                Documento = x.Documento,
                Nombre = x.Nombre
            };
        }

    }
}
