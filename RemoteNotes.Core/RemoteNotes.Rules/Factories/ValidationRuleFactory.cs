using System;
using System.Collections.Generic;
using System.Text;
using RemoteNotes.Rules.Contract;
using RemoteNotes.Rules.Rules;

namespace RemoteNotes.Rules.Factories
{
    public class ValidationRuleFactory : IValidationRuleFactory
    {
        readonly Dictionary<Type, object> ruleCollection = new Dictionary<Type, object>();
        public ValidationRuleFactory()
        {
            // Extension point of the factory
            this.ruleCollection.Add(typeof(IEnterOperationValidationRule),
             new EnterOperationValidationRule());
        }
        public T Create<T>()
        {
            Type type = typeof(T);
            if (!this.ruleCollection.ContainsKey(type))
            {
                throw new MissingMemberException(type.ToString() +
                 "is missing in the rule collection");
            }
            return (T)this.ruleCollection[type];
        }
    }
}
