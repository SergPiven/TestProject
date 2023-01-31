using RemoteNotes.Service.Domain.Data;
using System;

namespace RemoteNotes.Service.Domain.Transform
{
    public class UserTransformer
    {
        public UserInfo Transform(User user)
        {
            UserInfo userInfo = new UserInfo(user.Login);
            return userInfo;
        }
    }
}
