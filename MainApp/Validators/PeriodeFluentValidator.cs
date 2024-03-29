﻿using FluentValidation;

namespace MainApp.Validators
{
    public class PeriodeFluentValidator : AbstractValidator<Periode>
    {

        public PeriodeFluentValidator()
        {
            RuleFor(x => x.Tahun)
                .NotEmpty();

            RuleFor(x => x.Status).Equal(Models.StatusKas.Baru).When(x => x.Id <= 0);

        }

        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<Periode>.CreateWithOptions((Periode)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };
    }
}
