using Balta.Payment.Model.Enums;

namespace Balta.Payment.Abstractions.Validator
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
