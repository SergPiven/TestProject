using RemoteNotes.Rules.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteNotes.Rules.Rules
{
    public class PasswordValidationRule : ValidationRuleBase
    {
        public PasswordValidationRule() : base( "Password must be a string composed of: letters, digits, _") { }

        public ValidationResult IsValid(string password)
        {
            ValidationResult validationResult = new ValidationResult();
            if (password == null || !password.IsStringWithNumbersAndUnderscores())
            {
                string errorMessage = this.GetErrorMessage();
                validationResult = new ValidationResult(false, errorMessage);
            }
            return validationResult;
        }
    }
}
