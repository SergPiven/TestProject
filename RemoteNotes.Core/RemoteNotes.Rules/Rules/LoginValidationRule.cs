using RemoteNotes.Rules.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteNotes.Rules.Rules
{
    public class LoginValidationRule : ValidationRuleBase
    {
        public LoginValidationRule() : base("Login must be a string composed of letters and digits") { }

        public ValidationResult IsValid(string login)
        {
            ValidationResult validationResult = new ValidationResult();
            if (login == null || !login.IsStringWithNumbers())
            {
                string errorMessage = this.GetErrorMessage();
                validationResult = new ValidationResult(false, errorMessage);
            }
            return validationResult;
        }
    }
}
