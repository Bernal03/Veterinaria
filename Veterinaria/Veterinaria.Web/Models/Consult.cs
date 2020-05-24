using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Veterinaria.Web.Models
{
    public class Consult
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Fecha de consulta")]
        public DateTime ConsultDate { get; set; }
        [Required]
        [Display(Name = "Descripción")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Tipo de consulta")]
        public string ConsultType { get; set; }
        public Veterinary Veterinary { get; set; }
        public Pet Pet { get; set; }

    }
}