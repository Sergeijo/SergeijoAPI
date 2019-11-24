using System;
using FluentValidation;
using Web.Api.Models.Request;

namespace Web.Api.Models.Validation
{
    public class AddUserRequestValidator : AbstractValidator<AddUserRequest>
    {
        public AddUserRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .Length(2, 30)
                .Matches(@"^[a-zA-Z0-9_]*$"); // Only letters, numbers and _
            RuleFor(x => x.Birthdate)
                .NotEmpty()
                .LessThan(DateTime.Now);
            RuleFor(x => x.Password)
                .NotEmpty()
                .Length(6, 15);
        }
    }
}
