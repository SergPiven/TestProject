using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteNotes.Rules.Contract
{
    public interface IEnterOperationValidationRule
    {
        ValidationResult IsValid(string login, string password);
        ValidationResult ValidateLogin(string login);
        ValidationResult ValidatePassword(string password);
    }
}
