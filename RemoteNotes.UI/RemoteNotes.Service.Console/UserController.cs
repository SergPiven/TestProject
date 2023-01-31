using Microsoft.AspNetCore.SignalR;
using RemoteNotes.Service.Domain;
using RemoteNotes.Service.Domain.Data;
using RemoteNotes.Service.Domain.Transform;
using System.Threading.Tasks;

namespace RemoteNotes.Service.Console
{
    public class UserController
    {
        private readonly IHubContext<MainHub> hubContext;
        private readonly IUserManager userManager;
        private readonly UserTransformer userTransformer;
        public UserController(IHubContext<MainHub> hubContext, IUserManager userManager)
        {
            this.hubContext = hubContext;
            this.userManager = userManager;
            this.userTransformer = new UserTransformer();
        }
        public async Task<UserInfo> GetUserInfoAsync(string login)
        {
            User user = await this.userManager.GetUserByLoginAsync(login);
            return this.userTransformer.Transform(user);
        }
    }
}