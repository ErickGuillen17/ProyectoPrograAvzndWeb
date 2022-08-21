using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Entities
{
    [Keyless]
    public class SP_Consultar_Candidato_Result
    {
        public string NOMBRE_CANDIDATO { get; set; } = null!;
        public string APELLIDO_CANDIDATO { get; set; } = null!;
        public int EXP_CANDIDATO { get; set; }
        public string GRADO_ESTUDIO { get; set; } = null!;
        public int TELEFONO_CANDIDATO { get; set; }
        public long AREA_INTERES { get; set; }
        public string CORREO_USUARIO { get; set; } = null!;
        public string categoria_descripcion { get; set; } = null!;
    }

}
