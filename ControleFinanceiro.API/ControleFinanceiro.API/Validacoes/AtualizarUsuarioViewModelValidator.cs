using ControleFinanceiro.API.ViewModels;
using FluentValidation;

namespace ControleFinanceiro.API.Validacoes
{
    public class AtualizarUsuarioViewModelValidator : AbstractValidator<AtualizarUsuarioViewModel>
    {
        public AtualizarUsuarioViewModelValidator()
        {
            RuleFor(c => c.UserName)
                .NotNull().WithMessage("Preencha o nome de usuário")
                .NotEmpty().WithMessage("Preencha o nome de usuário")
                .MinimumLength(6).WithMessage("Use mais caractéres")
                .MaximumLength(50).WithMessage("Use menos caractéres");           

            RuleFor(c => c.CPF)
              .NotNull().WithMessage("Preencha o CPF")
              .NotEmpty().WithMessage("Preencha o CPF")
              .MinimumLength(1).WithMessage("Use mais caractéres")
              .MaximumLength(20).WithMessage("Use menos caractéres");

            RuleFor(c => c.Profissao)
              .NotNull().WithMessage("Preencha a profissão")
              .NotEmpty().WithMessage("Preencha a profissão")
              .MinimumLength(1).WithMessage("Use mais caractéres")
              .MaximumLength(50).WithMessage("Use menos caractéres");

            RuleFor(c => c.Foto)
            .NotNull().WithMessage("Escolha a foto")
            .NotEmpty().WithMessage("Escolha a foto");           

            RuleFor(c => c.Email)
             .NotNull().WithMessage("Preencha o email")
             .NotEmpty().WithMessage("Preencha o email")
             .MinimumLength(1).WithMessage("Use mais caractéres")
             .MaximumLength(30).WithMessage("Use menos caractéres")
             .EmailAddress().WithMessage("Email inválido");
            
        }
    }
}
