using Depot.Business.Models.Validations.Documentos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Depot.Business.Models.Validations
{
    public class FornecedorValidation : AbstractValidator<Fornecedor>
    {
        public FornecedorValidation()
        {
            RuleFor(f => f.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 100)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(f => f.Documento.Length).Equal(CnpjValidacao.TamanhoCnpj)
                .WithMessage("O Campo Documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}. ");
            RuleFor(f => CnpjValidacao.Validar(f.Documento)).Equal(true)
            .WithMessage("O documento fornecodo é inválido");




            //RuleFor(f => f.Documento.Length).Equal(CnpjValidacao.TamanhoCnpj)
            //                .WithMessage("O Campo Documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}. ");
            //                RuleFor(f => CnpjValidacao.Validar(f.Documento)).Equal(true)
            //                .WithMessage("O documento fornecodo é inválido");

        }
    }
}
