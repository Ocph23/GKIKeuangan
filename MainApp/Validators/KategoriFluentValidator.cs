using FluentValidation;

namespace MainApp.Validators
{
    public class KategoriFluentValidator   :AbstractValidator<Kategori>
    {

        public KategoriFluentValidator()
        {
            RuleFor(x => x.Kode)
                .NotEmpty()
                .Length(1, 100);

            RuleFor(x => x.Nama)
                .NotEmpty();
        }

        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<Kategori>.CreateWithOptions((Kategori)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };
    }
}
