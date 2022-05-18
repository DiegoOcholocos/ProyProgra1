using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace appproy.Models
{
    [Table("t_usersmatricula")]
    public class UsersMatricula
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
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? BirthDate { set; get; }
    	[Column("Edad")]
        public string? Edad { get; set; }
        [Column("Celular")]
        public string? Celular { get; set; }
        [Column("Operador")]
        public string? Operador { get; set; }
        [Column("Sexo")]
        public string? Sexo { get; set; }
        [Column("Grado_Academico")]
        public string? Grado_Academico { get; set; }
        [Column("Correo-GMAIL")]
        public string? Correo { get; set; }
        [Column("Direccion")]
        public string? Direccion { get; set; }
        [Column("Distrito")]
        public string? Distrito { get; set; }
        [Column("Vacuna")]
        public string? Vacuna { get; set; }
        [Column("Computacion_info")]
        public string? Computacion_info { get; set; }
        [Column("Confeccion_info")]
        public string? Confeccion_info { get; set; }
        [Column("Estetica_info")]
        public string? Estetica_info { get; set; }
        [Column("Horario")]
        public string? Horario { get; set; }
        [Column("Foto_DNI")]
        public string? Foto_DNI { get; set; }
        [Column("Codigo_Voucher")]
        public string? Codigo_Voucher { get; set; }
        [Column("Foto_Voucher")]
        public string? Foto_Voucher { get; set; }
        [Column("Apuntes")]
        public string? Apuntes { get; set; }
    }
}