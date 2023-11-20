using System.ComponentModel.DataAnnotations;

namespace IdentityOAuthServer.Model
{
    public class LoginViewModel
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}
