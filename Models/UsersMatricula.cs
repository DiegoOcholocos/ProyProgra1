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



        
        [Column("Año")]
        public string? Año { get; set; }





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
        [Column("Area")]
        public string? Area { get; set; }
        [Column("Curso")]
        public string? Curso { get; set; }
        [Column("Horario")]
        public string? Horario { get; set; }
        [Column("Foto_DNI_Cara")]
        public string? Foto_DNI_Cara { get; set; }
        [Column("Foto_DNI_Sello")]
        public string? Foto_DNI_Sello { get; set; }
        [Column("Codigo_Voucher")]
        public string? Codigo_Voucher { get; set; }
        [Column("Foto_Voucher")]
        public string? Foto_Voucher { get; set; }
        [Column("Mes_Matricula")]
        public string? Mes_Matricula { get; set; }
        [Column("Status")]
        public string? Status { get; set; } ="PENDIENTE";
        [Column("Apuntes")]
        public string? Apuntes { get; set; }
    }
}