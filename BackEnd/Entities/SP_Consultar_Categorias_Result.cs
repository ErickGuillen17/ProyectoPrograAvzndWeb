using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Entities
{
    public class SP_Consultar_Categorias_Result
    {
        public long ID_CATEGORIA { get; set; }
        public string CATEGORIA_DESCRIPCION { get; set; } = null!;
    }
}
