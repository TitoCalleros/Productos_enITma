using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_BLL.DTOs
{
    [DataContract]
    public class CreacionProductoDTO
    {
        [DataMember]
        public string Descripcion { get; set; }

        [DataMember]
        public int IdUsuario { get; set; }        
    }
}
