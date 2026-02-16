using Balta.Payment.Abstractions.Logger;
using Balta.Payment.Abstractions.Processor;
using Balta.Payment.Abstractions.Validator;
using Balta.Payment.Model.Enums;

namespace Balta.Payment.Abstractions.Services
{
    public interface IPaymentService
    {
        public EnumPaymentGateway Gateway { get; }

        public IPaymentProcessor Processor { get; }
        public IPaymentValidator Validator { get; }
        public IPaymentLogger Logger { get; }

        /// <summary>
        /// Process the payment, using a card number and specifying the payment amount.
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="cardNumber"></param>
        public void ProcessPayment(decimal amount, string cardNumber);
    }
}
