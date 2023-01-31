using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteNotes.Rules.Rules
{
    public abstract class ValidationRuleBase
    {
        protected string ruleDescription;
        public ValidationRuleBase(string ruleDescription)
        {
            this.ruleDescription = ruleDescription;
        }
        protected virtual string GetErrorMessage()
        {
            string errorMessage = "" + this.ruleDescription + "";
            return errorMessage;
        }
    }
}
