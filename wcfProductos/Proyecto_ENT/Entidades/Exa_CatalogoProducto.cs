using System.ComponentModel.DataAnnotations;

namespace Proyecto_ENT.Entidades
{
    public class Exa_CatalogoProducto
    {
        [Key]
        public int IdProducto { get; set; }        
        public string Descripcion { get; set; }
        public int IdUsuario { get; set; }        
    }
}
