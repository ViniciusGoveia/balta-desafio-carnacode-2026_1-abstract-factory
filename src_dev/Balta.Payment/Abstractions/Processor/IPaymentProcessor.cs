using Balta.Payment.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Balta.Payment.Abstractions.Processor
{
    public interface IPaymentProcessor
    {
        public EnumPaymentGateway Gateway { get; }

        /// <summary>
        /// Process the payment, using a card number and specifying the payment amount.
        /// This method belongs to the payment processor abstraction.
        /// </summary>
        /// <param name="amount">The amount to be processed in the transaction.
        /// </param>
        /// <param name="cardNumber"></param>
        /// <returns>A string containing the transaction code.</returns>
        public string ProcessTransaction(decimal amount, string cardNumber);
    }
}
