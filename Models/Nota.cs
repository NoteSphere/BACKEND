using BACKEND.Data;
namespace BACKEND.Models{
    public class Nota{
        public int Id { get; set; }
        public int IdCategorias { get; set; }
        public string Texto { get; set; }
        public string Titulo { get; set; }
        public string Estado { get; set; }
        public DateTime Fecha { get; set; }
    }
}
