using System.ComponentModel.DataAnnotations;

namespace WS_ScaneApp.Models.ProjectRequests
{
    public class AuthRequest
    {
        [Required] [MinLength(1)]
        public string Email { get; set; }
        
        [Required] [MinLength(1)]
        public string Password { get; set; }
    }
}
