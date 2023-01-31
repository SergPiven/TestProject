using System;
using System.Collections.Generic;

namespace RemoteNotes.Service.Console
{
    public class ManagerFactory : IManagerFactory
    {

        private Dictionary<Type, object> dictionary = new Dictionary<Type, object>();

        public ManagerFactory() 
        {
            dictionary.Add(typeof(IUserManager), new UserManager());
        }
        public T Create<T>()
        {
            Type type = typeof(T);
            if (!this.dictionary.ContainsKey(type))
            {
                throw new MissingMemberException(type.ToString() + "is missing in the view model collection");
            }
            return (T)this.dictionary[type];
        }
    }
}