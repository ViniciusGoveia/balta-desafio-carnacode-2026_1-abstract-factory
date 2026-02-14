using Balta.Payment.Interfaces.Logger;
using Balta.Payment.Interfaces.Processor;
using Balta.Payment.Interfaces.Validator;
using Balta.Payment.Model.Enums;

namespace Balta.Payment.Interfaces.Services
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
