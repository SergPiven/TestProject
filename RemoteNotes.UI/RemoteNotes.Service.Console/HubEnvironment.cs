using Microsoft.AspNetCore.SignalR;

namespace RemoteNotes.Service.Console
{
    public class HubEnvironment
    {
        public UserController userController;
        public HubEnvironment(IHubContext<MainHub> hubContext,
         IManagerFactory managerFactory)
        {
            IUserManager userManager = managerFactory.Create<IUserManager>();
            this.userController = new UserController(hubContext, userManager);
        }
    }
}