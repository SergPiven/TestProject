using RemoteNotes.Rules.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteNotes.Rules.Rules
{
    public class EnterOperationValidationRule : IEnterOperationValidationRule
    {
        private readonly LoginValidationRule loginValidationRule;
        private readonly PasswordValidationRule passwordValidationRule;
        public EnterOperationValidationRule()
        {
            this.passwordValidationRule = new PasswordValidationRule();
            this.loginValidationRule = new LoginValidationRule();
        }
        public ValidationResult IsValid(string login, string password)
        {
            List<ValidationResult> validationResultCollection = new List<ValidationResult>
            {
                this.loginValidationRule.IsValid(login),
                this.passwordValidationRule.IsValid(password)
            };
            return new ValidationResult(validationResultCollection);
        }
        public ValidationResult ValidateLogin(string login)
        {
            return this.loginValidationRule.IsValid(login);
        }
        public ValidationResult ValidatePassword(string password)
        {
            return this.passwordValidationRule.IsValid(password);
        }
    }
}
