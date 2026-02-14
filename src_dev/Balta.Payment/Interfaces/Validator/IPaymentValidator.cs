using Balta.Payment.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Balta.Payment.Interfaces.Validator
{
    public interface IPaymentValidator
    {
        public EnumPaymentGateway Gateway { get; }

        /// <summary>
        /// Method to validate a given card number.
        /// </summary>
        /// <param name="cardNumber"></param>
        /// <returns></returns>
        public bool ValidateCard(string cardNumber);
    }
}
