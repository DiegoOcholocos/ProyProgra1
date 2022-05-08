using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace appproy.Models
{
    [Table("t_Contacto")]
    public class Contacto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string name {get; set;}
        [Column("email")]
        public string email {get; set;}
        [Column("subject")]
        public string subject {get; set;}
        [Column("comment")]
        public string comment {get; set;}
    }
}