using FluentValidation;

namespace MainApp.Validators
{
    public class KasFluentValidator:AbstractValidator<Kas>
    {

        public KasFluentValidator()
        {
            RuleFor(x => x.Tanggal)
              .NotNull();

            RuleFor(x => x.Akun)
                .NotNull();

            RuleFor(x => x.Jumlah)
                .GreaterThan(0);
        }

        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<Kas>.CreateWithOptions((Kas)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };
    }
}
