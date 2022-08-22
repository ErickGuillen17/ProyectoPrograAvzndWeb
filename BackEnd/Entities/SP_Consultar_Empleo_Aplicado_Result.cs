using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Entities
{
    [Keyless]
    public class SP_Consultar_Empleo_Aplicado_Result
    {
        public long ID_EMPLEO { get; set; }
        public long ID_SOLICITUD { get; set; }
        public DateTime FECHA_SOLICITUD { get; set; }
        public string CORREO_CANDIDATO { get; set; }
    }

}
