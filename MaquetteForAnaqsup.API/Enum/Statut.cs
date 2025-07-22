using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquetteForAnaqsup.API.Enum
{
    public enum Statut
    {
        [Display(Name = "Non Validé")]
        NonValide,
        [Display(Name = "Validé")]
        Valide,
        [Display(Name = "Cloturé")]
        Cloture
    }
}
