namespace GiriPet.Logic.Dtos
{
    public class LoginRequestDto
    {
        private string _email = null!;
        public string Email
        {
            get
            {
                return _email.ToLower();
            }
            set
            {
                _email = value.ToLower();
            }
        }
        public string Password { get; set; } = null!;
    }
}
