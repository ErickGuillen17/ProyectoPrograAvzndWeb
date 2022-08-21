using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Models
{
    public class EmpleoViewModel
    {
        //public Empleo()
        //{
        //    Solicitud = new HashSet<Solicitud>();
        //}

        [Key]
        public long IdEmpleo { get; set; }

        [Display(Name = "Categoría/Área")]
        public long IdCategoria { get; set; }

        [Required(ErrorMessage = "Debe indicar la experiencia mínima")]
        [Display(Name = "Experiencia requerida")]
        public int ExpMinima { get; set; }

        [Required(ErrorMessage = "Debe indicar el grado de estudio")]
        [Display(Name = "Grado de estudio")]
        public string GradoEstudio { get; set; } = null!;

        [Required(ErrorMessage = "Debe indicar su compañía/empresa")]
        [Display(Name = "Compañía")]
        public string Compania { get; set; } = null!;

        [Required(ErrorMessage = "Debe indicar el nombre del empleo")]
        [Display(Name = "Nombre")]
        public string EmpleoNombre { get; set; } = null!;

        [Required(ErrorMessage = "Debe indicar el estado del empleo")]
        [Display(Name = "Estado")]
        public string EstadoPuesto { get; set; } = null!;

        [Required(ErrorMessage = "Debe indicar la descripción del empleo")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; } = null!;

        [Required(ErrorMessage = "Debe indicar los requisitos del empleo")]
        [Display(Name = "Requisitos")]
        public string Requisitos { get; set; } = null!;

        public string CorreoReclutador { get; set; } = null!;

        [Display(Name = "Categoría/Área")]
        public string CategoriaDescripcion { get; set; } = null!;

        public IEnumerable<Categoria> Categorias { get; set; }

        //public virtual Reclutador CorreoReclutadorNavigation { get; set; } = null!;
        //public virtual Categoria IdCategoriaNavigation { get; set; } = null!;
        //public virtual ICollection<Solicitud> Solicitud { get; set; }

    }
}
