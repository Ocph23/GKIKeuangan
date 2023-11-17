using FluentValidation;
using MainApp.Models;

namespace MainApp.Validators
{
    public class PeriodeKasFluentValidator : AbstractValidator<PeriodeKas>
    {

        public PeriodeKasFluentValidator()
        {
            RuleFor(x => x.Bulan)
               .GreaterThan(0).LessThan(13);
            RuleFor(x => x.Mulai)
                .NotEmpty();

            RuleFor(x => x.Berakhir)
                .NotEmpty();

            RuleFor(x => x.Periode)
                .NotEmpty();

            RuleFor(x => x.PemegangKas)
            .NotEmpty();
        }

        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<PeriodeKas>.CreateWithOptions((PeriodeKas)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };
    }
}
