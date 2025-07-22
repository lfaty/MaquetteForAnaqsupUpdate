using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MaquetteForAnaqsup.API.Identity.DTO
{
    public class AddUserDto
    {
        [Required(ErrorMessage = "Usermane est obligatoire")]
        [StringLength(100, ErrorMessage = "Usermane est entre 5 et 20 caractaires", MinimumLength = 5)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password est obligatoire")]
        [StringLength(255, ErrorMessage = "Password est entre 5 et 225 caractaires", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password est obligatoire")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [NotMapped]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Role est obligatoire")]
        public List<string> Roles { get; set; }

        [Required(ErrorMessage = "N° Tél est obligatoire")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Universite est obligatoire")]
        public string? UniversiteId { get; set; }
    }
}
