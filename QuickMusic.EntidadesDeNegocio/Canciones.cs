using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickMusic.EntidadesDeNegocio
{
   public class Canciones
    {
        [Key]
        public int Id { get; set; }


        [ForeignKey("Artista")]
        [Required(ErrorMessage = "Artista es obligatorio")]
        [Display(Name = "Artista")]
        public int Id_Artista { get; set; }

        [ForeignKey("Genero")]
        [Required(ErrorMessage = "Genero es obligatorio")]
        [Display(Name = "Genero")]
        public int Id_Genero { get; set; }

        [Required(ErrorMessage = "Nombre es obligatorio")]
        [StringLength(30, ErrorMessage = "Maximo 30 caracteres")]
        public string Nombre { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }
       public Artista Artista { get; set; }
        public Genero Genero { get; set; }
    }
}
