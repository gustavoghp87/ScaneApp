using WS_ScaneApp.Models.ProjectRequests;
using WS_ScaneApp.Models.ProjectResponses;

namespace WS_ScaneApp.Services
{
    public interface IUserService
    {
        UserResponse Auth(AuthRequest model);
    }
}
