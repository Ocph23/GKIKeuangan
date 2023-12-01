using FluentValidation;
using MainApp.Models;

namespace MainApp.Validators
{
    public class UserFluentValidator : AbstractValidator<UserModel>
    {

        public UserFluentValidator()
        {
            RuleFor(x => x.Role)
                .NotEmpty();
            RuleFor(x => x.UserName)
                .NotEmpty().EmailAddress(); 

            RuleFor(x => x.Nama)
                .NotEmpty();
        }

        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<UserModel>.CreateWithOptions((UserModel)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };
    }
}
