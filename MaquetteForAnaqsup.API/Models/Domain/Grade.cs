using MaquetteForAnaqsup.API.Base;

namespace MaquetteForAnaqsup.API.Models.Domain
{
    public class Grade : IEntityBase
    {
        public Guid Id { get; set; }
        public string? LibelleGrade { get; set; }
        public string? CodeUniv { get; set; }
        public DateTime DateCreation { get; set; } = DateTime.Now;
        public DateTime DateUpdate { get; set; }


        public virtual ICollection<Formation> Formations { get; set; } = new HashSet<Formation>();
    }
}
