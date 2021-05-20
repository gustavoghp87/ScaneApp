using System.Linq;
using WS_ScaneApp.Models;
using WS_ScaneApp.Models.ProjectRequests;
using WS_ScaneApp.Models.ProjectResponses;
using WS_ScaneApp.Tools;

namespace WS_ScaneApp.Services
{
    public class UserService : IUserService
    {
        public UserResponse Auth(AuthRequest model)
        {
            UserResponse userResponse = new();
            using (var context = new ScaneAppContext())
            {
                string encryptedPsw = Encrypt.GetSHA256(model.Password);
                var user = context.Users.Where(x => x.Email == model.Email && x.Password == encryptedPsw).FirstOrDefault();
                if (user == null) return null;
                userResponse.Email = user.Email;
                userResponse.Token = "abcdefghijklmnopqrstuvwxyz"; 
            }
            return userResponse;
        }
    }
}
