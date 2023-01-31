using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteNotes.Rules.Contract
{
    public interface IValidationRuleFactory
    {
        T Create<T>();
    }
}
