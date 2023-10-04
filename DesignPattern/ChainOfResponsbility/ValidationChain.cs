using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DesignPattern.ChainOfResponsbility
{
    //motovation to have a chain of steps on the request
    // like exception handling and middleware in ASP.net Core it chain things like .AddMVC() , .Add ... on the request 
    // to douclped the sender from the reciver 
    // example steps of validation chained on the input ( not empty , match email foramt , Password Strength Check)
    // two ways to do it 1 - reference on each next handler  2- centeralized the main event handler (mediator)
    public abstract class ValidationHandler
    {
        protected ValidationHandler nextHandler;
        public void SetNextHandler(ValidationHandler handler) { this.nextHandler = handler; }
        public abstract bool IsValid(UserInput input);
    }
    public class NonEmptyValidator : ValidationHandler
    {
        public override bool IsValid(UserInput input)
        {
            if (string.IsNullOrWhiteSpace(input.Email) || string.IsNullOrWhiteSpace(input.Password))
            {
                Console.WriteLine("Fields Should Not Be Empty.");
                return false;
            }
            return nextHandler?.IsValid(input) ?? true;
        }
    }
    public class EmailFormatValidator : ValidationHandler
    {
        public override bool IsValid(UserInput input)
        {
            // Regex for email validation.
            bool IsValidEmail = Regex.IsMatch(input.Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            if (!IsValidEmail)
            {
                Console.WriteLine("Invalid Email Format.");
                return false;
            }
            return nextHandler?.IsValid(input) ?? true;
        }
    }

    public class PasswordStrengthValidator : ValidationHandler
    {
        public override bool IsValid(UserInput input)
        {
            if (input.Password.Length < 8 || !input.Password.Any(char.IsUpper) ||
                !input.Password.Any(char.IsLower) || !input.Password.Any(char.IsDigit))
            {
                Console.WriteLine("Weak password. Ensure it's at least 8 characters and contains uppercase, lowercase, and a digit.");
                return false;
            }
            return nextHandler?.IsValid(input) ?? true;
        }
    }
    public class UserInput
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
