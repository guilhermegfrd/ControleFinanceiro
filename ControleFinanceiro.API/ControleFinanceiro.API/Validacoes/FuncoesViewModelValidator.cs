using ControleFinanceiro.API.ViewModels;
using FluentValidation;

namespace ControleFinanceiro.API.Validacoes
{
    public class FuncoesViewModelValidator : AbstractValidator<FuncoesViewModel>
    {
        public FuncoesViewModelValidator()
        {
            RuleFor(c => c.Name)
                .NotNull().WithMessage("Preencha a função")
                .NotEmpty().WithMessage("Preencha a função")
                .MinimumLength(1).WithMessage("Use mais caractéres")
                .MaximumLength(50).WithMessage("Use menos caractéres");

            RuleFor(c => c.Descricao)
               .NotNull().WithMessage("Preencha a descrição")
               .NotEmpty().WithMessage("Preencha a descrição")
               .MinimumLength(1).WithMessage("Use mais caractéres")
               .MaximumLength(50).WithMessage("Use menos caractéres");                  
        }
    }
}
