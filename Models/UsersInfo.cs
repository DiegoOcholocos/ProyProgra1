using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace appproy.Models
{
    [Table("t_usersinfo")]
    public class UsersInfo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]

        public int Id { get; set; }
        
        [Column("UserID")]
        public string UserID { get; set; }
        [Column("Name")]
        public string? Name { get; set; }
        [Column("LastName")]
        public string? LastName { get; set; }
        [Column("DNI")]
        public string? DNI { get; set; }
        [Column("Pasaporte")]
        public string? Pasaporte { get; set; }
        [Column("Carnet_de_extranjeria")]
        public string? Carnet_de_extranjeria { get; set; }
        [Column("Nacionalidad")]
        public string? Nacionalidad { get; set; }
        [Column("Mail")]
        public string? Mail { get; set; }
        
        [Column("Telefono")]
        public string? Telefono { get; set; }
        [Column("Direction")]
        public string? Direction { get; set; }
        [Column("Photo")]
        public string? Photo { get; set; }
    }
}