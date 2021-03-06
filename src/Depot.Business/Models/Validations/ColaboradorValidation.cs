﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Depot.Business.Models.Validations
{
    public class ColaboradorValidation : AbstractValidator<Colaborador>
    {
        public ColaboradorValidation()
        {
            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido")
                .Length(2, 100)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Senha)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido")
                .Length(2, 100)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength}");
        }
    }
}
