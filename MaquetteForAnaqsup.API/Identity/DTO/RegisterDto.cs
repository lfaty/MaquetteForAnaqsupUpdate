using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaquetteForAnaqsup.API.Identity.DTO
{
    public class RegisterDto
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email est obligatoire")]
        [StringLength(100, ErrorMessage = "Usermane est entre 5 et 20 caractaires", MinimumLength = 5)]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }

        [Display(Name = "Mot de passe")]
        [Required(ErrorMessage = "Password est obligatoire")]
        [StringLength(255, ErrorMessage = "Password est entre 5 et 225 caractaires", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirmation")]
        [Required(ErrorMessage = "Confirm Password est obligatoire")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [NotMapped]
        public string ConfirmPassword { get; set; }

        [Display(Name = "N° Tel")]
        [Required(ErrorMessage = "N° Tél est obligatoire")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Display(Name = "Choisir role")]
        [Required(ErrorMessage = "Role est obligatoire")]
        //public string? RoleId { get; set; }
        public List<string>? Roles { get; set; }
        [Display(Name = "Choisir universite")]
        [Required(ErrorMessage = "Universite est obligatoire")]
        public string? UniversiteId { get; set; }
    }
}
