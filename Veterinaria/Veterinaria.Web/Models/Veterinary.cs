using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Veterinaria.Web.Models
{
    public class Veterinary
    {
        public int Id { get; set; }
        [Display(Name ="Descripción")]
        public string Description { get; set; }
        public ICollection<Consult> Consults { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}