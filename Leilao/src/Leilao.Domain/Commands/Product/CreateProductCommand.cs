using Leilao.Domain.Validations.Product;

namespace Leilao.Domain.Commands.Product {

    public class CreateProductCommand : ProductCommand {

        public CreateProductCommand(string name, decimal price) {
            Name = name;
            Price = price;
        }

        public override bool IsValid() {
            ValidationResult = new CreateProductCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }

    }
}
