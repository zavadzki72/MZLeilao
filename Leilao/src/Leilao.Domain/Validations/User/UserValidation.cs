using FluentValidation;
using Leilao.Domain.Commands.User;
using System;

namespace Leilao.Domain.Validations.User {

    public abstract class UserValidation<T> : AbstractValidator<T> where T : UserCommand {

        #region Validation Messages
        public static string FieldRequired = "Invalid fields try again";
        #endregion

        protected void ValidateName() {
            RuleFor(c => c.Name).NotNull().WithMessage(FieldRequired);
        }

        protected void ValidateBirthDate() {
            RuleFor(c => c.BirthDate).NotEqual(DateTime.MinValue).WithMessage(FieldRequired);
        }

    }
}
