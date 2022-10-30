using ControleFinanceiro.BLL.Models;
using FluentValidation;

namespace ControleFinanceiro.API.Validacoes
{
    public class CategoriaValidator : AbstractValidator<Categoria>
    {
        public CategoriaValidator()
        {
            RuleFor(c => c.Nome)
                .NotNull().WithMessage("Preencha o nome")
                .NotEmpty().WithMessage("Preencha o nome")
                .MinimumLength(6).WithMessage("Use mais caractéres")
                .MaximumLength(50).WithMessage("Use menos caractéres");

            RuleFor(c => c.Icone)
               .NotNull().WithMessage("Preencha o ícone")
               .NotEmpty().WithMessage("Preencha o ícone")
               .MinimumLength(1).WithMessage("Use mais caractéres")
               .MaximumLength(15).WithMessage("Use menos caractéres");

            RuleFor(c => c.TipoId)
               .NotNull().WithMessage("Preencha o tipo")
               .NotEmpty().WithMessage("Preencha o tipo");               
        }
    }
}
