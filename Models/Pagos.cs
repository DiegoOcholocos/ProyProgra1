using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace appproy.Models
{
    [Table("t_pagos")]
    public class Pagos
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
        public string DNI { get; set; }
        [Column("Celular")]
        public string Celular { get; set; }
        [Column("Area")]
        public string? Area { get; set; }
        [Column("Curso")]
        public string? Curso { get; set; }
        
        [Column("Turno")]
        public string Turno { get; set; }
        [Column("Monto")]
        public string Monto { get; set; }
        [Column("Codigo_recibo")]
        public string Codigo_recibo { get; set; }
        [Column("Foto_recibo")]
        public string Foto_recibo { get; set; }
        [Column("Status")]
        public string? Status { get; set; } ="PENDIENTE";
        [Column("Apuntes")]
        public string? Apuntes { get; set; }
        [Column("Mes_Matricula")]
        public string? Mes_Matricula { get; set; }
        [Column("Año")]
        public string? Año { get; set; }

    }
}