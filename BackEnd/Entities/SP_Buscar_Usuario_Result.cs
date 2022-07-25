using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Entities
{
    [Keyless]
    public class SP_Buscar_Usuario_Result
    {
        public string CORREO_USUARIO { get; set; } = null!;
        public string CONTRASENA { get; set; } = null!;
        public long ID_ROL { get; set; }
    }

}
