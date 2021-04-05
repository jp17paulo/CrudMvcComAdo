using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrudMvcComAdo.Models
{
    public class Times
    {
        [Display(Name = "Id")]
        public int TimesId { get; set; }

        [Required(ErrorMessage ="Informe o nome do time")]
        public string Time { get; set; }

        [Required(ErrorMessage = "Informe o estado do time")]
        [Display(Name = "Estado")]
        public string EstadoSigla { get; set; }

        public int EstadoId { get; set; }

        public string EstadoNome { get; set; }

        [Required(ErrorMessage = "Informe as cores do time")]
        public string Cores { get; set; }
    }
}