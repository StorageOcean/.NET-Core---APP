using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Model
{
    public partial class Productos
    {
        [Key]
        [Column("idProducto")]
        public int IdProducto { get; set; }
        [StringLength(100)]
        public string Descripcion { get; set; }
    }
}
