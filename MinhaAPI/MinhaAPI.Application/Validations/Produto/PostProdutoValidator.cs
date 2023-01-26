using FluentValidation;
using MinhaAPI.Application.Dtos.Produto;
using MinhaAPI.Application.Interfaces;

namespace MinhaAPI.Application.Validations.Produto
{
    public class PostProdutoValidator : AbstractValidator<PostProdutoDto>
    {
        private readonly IProdutoApplication produtoApplication;

        public PostProdutoValidator(IProdutoApplication produtoApplication)
        {
            this.produtoApplication = produtoApplication;

            RuleFor(x => x.Nome)
              .NotNull()
              .WithMessage("O campo nome não pode ser nulo.")

              .NotEmpty()
              .WithMessage("O campo nome não pode ser vazio.");

            RuleFor(x => x.Valor)
              .NotNull()
              .WithMessage("O campo valor não pode ser nulo.")

              .NotEmpty()
              .WithMessage("O campo valor não pode ser vazio.");

            RuleFor(x => x.Quantidade)
              .NotNull()
              .WithMessage("O campo quantidade não pode ser nulo.")

              .NotEmpty()
              .WithMessage("O campo quantidade não pode ser vazio.");

            RuleFor(x => x.Status)
             .NotNull()
             .WithMessage("O campo status não pode ser nulo.")

             .NotEmpty()
             .WithMessage("O campo status não pode ser vazio.")

             .IsInEnum()
             .WithMessage("O valor do campo status não é valido.");
        }
    }
}