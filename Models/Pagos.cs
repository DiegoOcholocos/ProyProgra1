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
        [Column("NOMBRES Y APELLIDOS")]
        public string? NOMBRES_Y_APELLIDOS { get; set; }
        [Column("DNI")]
        public string DNI { get; set; }
        [Column("Celular")]
        public string Celular { get; set; }
        [Column("Computacion_info")]
        public string? Computacion_info { get; set; }
        [Column("Confeccion_info")]
        public string? Confeccion_info { get; set; }
        [Column("Estetica_info")]
        public string? Estetica_info { get; set; }
        [Column("Turno")]
        public string Turno { get; set; }
        [Column("Monto")]
        public string Monto { get; set; }
        [Column("Codigo_recibo")]
        public string Codigo_recibo { get; set; }
        [Column("Foto_recibo")]
        public string Foto_recibo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? Creacion { set; get; } = DateTime.Now;
    }
}