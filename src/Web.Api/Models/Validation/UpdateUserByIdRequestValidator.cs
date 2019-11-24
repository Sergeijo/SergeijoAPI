using System;
using FluentValidation;
using Web.Api.Models.Request;

namespace Web.Api.Models.Validation
{
    public class UpdateUserByIdRequestValidator : AbstractValidator<UpdateUserRequest>
    {
        public UpdateUserByIdRequestValidator()
        {
            RuleFor(x => x.Updated_name)
                .NotEmpty()
                .Length(2, 30)
                .Matches(@"^[a-zA-Z0-9_]*$"); // Only letters, numbers and _
            RuleFor(x => x.Updated_birthdate)
                .NotEmpty()
                .LessThan(DateTime.Now);
            RuleFor(x => x.Updated_password)
                .NotEmpty()
                .Length(6, 15);
        }
    }
}
