using Leilao.Domain.Commands.User;

namespace Leilao.Domain.Validations.User {

    public class CreateUserCommandValidation : UserValidation<CreateUserCommand> {

        public CreateUserCommandValidation() {
            ValidateName();
            ValidateBirthDate();
        }

    }
}
