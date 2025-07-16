using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquetteForAnaqsup.API.Base
{
    public interface IEntityBase
    {
        Guid Id { get; set; }
        string? CodeUniv { get; set; }
    }
}
