using Leilao.Domain.Commands.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leilao.Domain.Validations.Product {

    public class CreateProductCommandValidation : ProductValidation<CreateProductCommand> {

        public CreateProductCommandValidation() {
            ValidateName();
            ValidatePrice();
        }
    }
}
