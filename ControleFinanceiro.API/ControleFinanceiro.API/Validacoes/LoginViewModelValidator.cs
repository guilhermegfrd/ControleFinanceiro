using ControleFinanceiro.API.ViewModels;
using FluentValidation;

namespace ControleFinanceiro.API.Validacoes
{
    public class LoginViewModelValidator : AbstractValidator<LoginViewModel>
    {
        public LoginViewModelValidator()
        {
            RuleFor(c => c.Email)
             .NotNull().WithMessage("Preencha o email")
             .NotEmpty().WithMessage("Preencha o email")
             .MinimumLength(10).WithMessage("Use mais caractéres")
             .MaximumLength(50).WithMessage("Use menos caractéres")
             .EmailAddress().WithMessage("Email inválido");

            RuleFor(c => c.Senha)
             .NotNull().WithMessage("Preencha a senha")
             .NotEmpty().WithMessage("Preencha a senha")
             .MinimumLength(6).WithMessage("Use mais caractéres")
             .MaximumLength(50).WithMessage("Use menos caractéres");
        }
    }
}
