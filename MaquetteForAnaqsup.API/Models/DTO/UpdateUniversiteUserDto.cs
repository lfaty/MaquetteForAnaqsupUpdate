namespace MaquetteForAnaqsup.API.Models.DTO
{
    public class UpdateUniversiteUserDto
    {
        public Guid Id { get; set; }
        public string? UniversiteId { get; set; }
        public string? UserId { get; set; }
        public string? RoleId { get; set; }
    }
}
