using System.Runtime.Serialization;

namespace Proyecto_BLL.DTOs
{
    [DataContract]
    public class ProductoDTO
    {
        [DataMember]
        public int IdProducto { get; set; }        
        [DataMember]
        public string Descripcion { get; set; }                
    }
}
