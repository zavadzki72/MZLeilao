﻿using FluentValidation;
using Leilao.Domain.Commands.Bid;
using System;

namespace Leilao.Domain.Validations.Bid {

    public abstract class BidValidation<T> : AbstractValidator<T> where T : BidCommand {

        #region Validation Messages
        public static string FieldRequired = "Invalid fields try again";
        #endregion

        protected void ValidateIdProduct() {
            RuleFor(c => c.ProductId).NotEqual(Guid.Empty).WithMessage(FieldRequired);
        }

        protected void ValidateIdUser() {
            RuleFor(c => c.UserId).NotEqual(Guid.Empty).WithMessage(FieldRequired);
        }

        protected void ValidatePriceOffer() {
            RuleFor(c => c.PriceOffer).NotNull().WithMessage(FieldRequired);
        }

        protected void ValidateQtdBids() {
            RuleFor(c => c.QtdBids).NotNull().WithMessage(FieldRequired);
        }

        protected void ValidateStartDate() {
            RuleFor(c => c.Start).NotEqual(DateTime.MinValue).WithMessage(FieldRequired);
        }

        protected void ValidateEndDate() {
            RuleFor(c => c.End).NotEqual(DateTime.MinValue).WithMessage(FieldRequired);
        }

    }
}