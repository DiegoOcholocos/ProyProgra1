using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace appproy.Models
{
    [Table("t_DataUsers")]
    public class DataUsers
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]

        public int Id { get; set; }
        
        [Column("NormalizedEmail")]
        public string NormalizedEmail { get; set; }
        [Column("DNI")]
        public int? DNI { get; set; }
        [Column("Name")]
        public string? Name { get; set; }
        [Column("LastName")]
        public string? LastName { get; set; }
        [Column("Telefono")]
        public string? Telefono { get; set; }
        [Column("Direction")]
        public string? Direction { get; set; }
    }
}