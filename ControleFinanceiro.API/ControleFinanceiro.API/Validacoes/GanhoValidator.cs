using ControleFinanceiro.BLL.Models;
using FluentValidation;

namespace ControleFinanceiro.API.Validacoes
{
    public class GanhoValidator : AbstractValidator<Ganho>
    {
        public GanhoValidator()
        {                         

            RuleFor(c => c.Descricao)
               .NotNull().WithMessage("Preencha a descrição")
               .NotEmpty().WithMessage("Preencha a descrição")
               .MinimumLength(1).WithMessage("Use mais caractéres")
               .MaximumLength(50).WithMessage("Use menos caractéres");

            RuleFor(c => c.CategoriaId)
            .NotNull().WithMessage("Escolha a categoria")
            .NotEmpty().WithMessage("Escolha a categoria");

            RuleFor(c => c.Valor)
               .NotNull().WithMessage("Preencha o valor")
               .NotEmpty().WithMessage("Preencha o valor")
               .InclusiveBetween(0, double.MaxValue).WithMessage("Valor Inválido");

            RuleFor(c => c.Dia)
              .NotNull().WithMessage("Preencha o dia")
              .NotEmpty().WithMessage("Preencha o dia")
              .InclusiveBetween(1, 31).WithMessage("Valor Inválido");

            RuleFor(c => c.MesId)
               .NotNull().WithMessage("Preencha o mês")
               .NotEmpty().WithMessage("Preencha o mês");

            RuleFor(c => c.Ano)
              .NotNull().WithMessage("Preencha o ano")
              .NotEmpty().WithMessage("Preencha o ano")
              .InclusiveBetween(2020, int.MaxValue).WithMessage("Valor Inválido");
        }
    }
}
