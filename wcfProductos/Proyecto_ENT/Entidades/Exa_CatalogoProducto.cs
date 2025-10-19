using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_ENT.Entidades
{
    [Table("Exa_CatalogoProducto", Schema = "Ventas")]
    public class Exa_CatalogoProducto
    {
        [Key]
        public int IdProducto { get; set; }        
        public string Descripcion { get; set; }
        public int IdUsuario { get; set; }
    }
}
