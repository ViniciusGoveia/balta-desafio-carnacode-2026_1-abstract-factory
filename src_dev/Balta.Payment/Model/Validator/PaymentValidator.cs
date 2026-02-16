using Balta.Payment.Abstractions.Validator;
using Balta.Payment.Model.Enums;
using Balta.Payment.Model.Helpers;

namespace Balta.Payment.Model.Validator
{
    public class PaymentValidator : IPaymentValidator
    {
        public EnumPaymentGateway Gateway { get; }

        private PaymentValidator(EnumPaymentGateway gateway) 
            => Gateway = gateway;

        public bool ValidateCard(string cardNumber)
        {
            Console.WriteLine($"{GatewayHelper.GetGatewayName(Gateway)}: Validando cartão...");

            return Gateway switch
            {
                EnumPaymentGateway.PagSeguro => cardNumber.Length == 16,
                EnumPaymentGateway.MercadoPago => cardNumber.Length == 16 && cardNumber.StartsWith('5'),
                EnumPaymentGateway.Stripe => cardNumber.Length == 16 && cardNumber.StartsWith('4'),
                _ => throw new NotImplementedException("This gateway was not implemented yet.")
            };
        }

        public static IPaymentValidator Get(EnumPaymentGateway gateway) 
            => new PaymentValidator(gateway);
    }
}
