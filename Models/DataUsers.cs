using System;
using System.Collections.Generic;
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
        
        [Column("idUser")]
        public int IdUser { get; set; }
        [Column("Correo")]
        public string? Correo { get; set; }
        [Column("Name")]
        public string? Name { get; set; }
        [Column("LastName")]
        public string? LastName { get; set; }
        [Column("Phone")]
        public string? Phone { get; set; }
        [Column("Direction")]
        public string? Direction { get; set; }
    }
}