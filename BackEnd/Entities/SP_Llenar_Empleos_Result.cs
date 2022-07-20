using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Entities
{
    [Keyless]
    public class SP_Llenar_Empleos_Result
    {
        public long IdEmpleo { get; set; }
        public long IdCategoria { get; set; }
        public int ExpMinima { get; set; }
        public string GradoEstudio { get; set; } = null!;
        public string Compania { get; set; } = null!;
        public string EmpleoNombre { get; set; } = null!;
        public string EstadoPuesto { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public string Requisitos { get; set; } = null!;
        public string CorreoReclutador { get; set; } = null!;
        public string CategoriaDescripcion { get; set; } = null!;
    }

}
