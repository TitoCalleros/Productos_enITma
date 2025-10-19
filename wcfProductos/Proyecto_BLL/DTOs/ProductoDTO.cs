using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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
