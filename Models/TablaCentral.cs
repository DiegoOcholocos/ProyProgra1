using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace appproy.Models
{
    [Table("t_tablacentral")]
    public class TablaCentral
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }   
        [Column("UserID")]
        public String UserID { get; set; }

    }
}