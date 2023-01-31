using RemoteNotes.Service.Domain;
using System.Threading.Tasks;

namespace RemoteNotes.Service.Console
{
    public interface IUserManager
    {
        Task<User> GetUserByLoginAsync(string login);
    }
}