using BackEnd.Entities;

namespace FrontEnd.Models
{
    public class usuarioCandidatoViewModel
    {
        public string NombreCandidato { get; set; } = null!;
        public string ApellidoCandidato { get; set; } = null!;
        public int ExpCandidato { get; set; }
        public string GradoEstudio { get; set; } = null!;
        public int TelefonoCandidato { get; set; }
        public long AreaInteres { get; set; }

        public IEnumerable<Categoria> Categorias { get; set; }
        public string CorreoUsuario { get; set; } = null!;

        public string contrasena { get; set; }
        public string confirmacion { get; set; }

        public long idrol { get; set; }
    }
}
