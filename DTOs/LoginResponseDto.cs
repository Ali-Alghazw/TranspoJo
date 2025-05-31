namespace TranspoJo.DTOs
{
    public class LoginResponseDto
    {
        public string Email { get; set; }
        public bool IsAdmin { get; set; }

        public string Token { get; set; }
    }
}
