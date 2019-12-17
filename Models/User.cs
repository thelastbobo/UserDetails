using FluentValidation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace UserDetails.Models
{
    public class User
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public DateTime DateOfBirth { get; set; }

        public override string ToString() => System.Text.Json.JsonSerializer.Serialize<User>(this);
    }

    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty()
                .Must(NotHaveFirstNameAndLastName)
                .WithMessage("The First Name or the Last Name appears in the UserName");
        }

        private bool NotHaveFirstNameAndLastName(User user, string Username)
        {
            return Username.ToLower().Contains(user.FirstName.ToLower())
                || Username.ToLower().Contains(user.LastName.ToLower())
                ? false : true;
        }
    }
}
