using FluentValidation;
using Leilao.Domain.Commands.Product;

namespace Leilao.Domain.Validations.Product {

    public abstract class ProductValidation<T> : AbstractValidator<T> where T : ProductCommand {

        #region Validation Messages
        public static string FieldRequired = "Invalid fields try again";
        #endregion

        protected void ValidateName() {
            RuleFor(c => c.Name).NotNull().WithMessage(FieldRequired);
        }

        protected void ValidatePrice() {
            RuleFor(c => c.Price).NotNull().WithMessage(FieldRequired);
        }

    }
}
