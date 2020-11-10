using Leilao.Domain.Validations.User;
using System;

namespace Leilao.Domain.Commands.User {

    public class CreateUserCommand : UserCommand {

        public CreateUserCommand(string name, DateTime birthDate) {
            Name = name;
            BirthDate = birthDate;
        }
        
        public override bool IsValid() {
            ValidationResult = new CreateUserCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
