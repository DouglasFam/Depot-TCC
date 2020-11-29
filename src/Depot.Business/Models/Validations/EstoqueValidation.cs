using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Depot.Business.Models.Validations
{
    public class EstoqueValidation : AbstractValidator<Estoque>
    {
        public EstoqueValidation()
        {
            RuleFor(e => e.Nome)
               .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido")
               .Length(2, 100)
               .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

        }
    }
}
