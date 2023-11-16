using FluentValidation;

namespace MainApp.Validators
{
    public class AkunFluentValidator:AbstractValidator<Akun>
    {

        public AkunFluentValidator()
        {
            RuleFor(x => x.Kode)
                .NotEmpty()
                .Length(1, 100);

            RuleFor(x => x.Uraian)
                .NotEmpty();

            RuleFor(x => x.Kategori)
                .NotEmpty();
        }

        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<Akun>.CreateWithOptions((Akun)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };
    }
}
