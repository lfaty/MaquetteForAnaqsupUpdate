namespace MaquetteForAnaqsup.API.Identity.DTO
{
    public class LoginResponseDto
    {
        public string JwtToken { get; set; }
        public string Username { get; set; }
        public string UserId { get; set; }
        public List<string> Roles { get; set; }
    }
}
