using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Entities
{
    [Keyless]
    public class SP_Empleos_Publicados_Result
    {
        public long ID_EMPLEO { get; set; }
        public long ID_CATEGORIA { get; set; }
        public int EXP_MINIMA { get; set; }
        public string GRADO_ESTUDIO { get; set; } = null!;
        public string COMPANIA { get; set; } = null!;
        public string EMPLEO_NOMBRE { get; set; } = null!;
        public string ESTADO_PUESTO { get; set; } = null!;
        public string DESCRIPCION { get; set; } = null!;
        public string REQUISITOS { get; set; } = null!;
        public string CORREO_RECLUTADOR { get; set; } = null!;
        public string categoria_descripcion { get; set; } = null!;
    }

}
