using Balta.Payment.Abstractions.Logger;
using Balta.Payment.Abstractions.Processor;
using Balta.Payment.Abstractions.Services;
using Balta.Payment.Abstractions.Validator;
using Balta.Payment.Model.Enums;
using Balta.Payment.Model.Helpers;
using Balta.Payment.Model.Logger;
using Balta.Payment.Model.Processor;
using Balta.Payment.Model.Validator;

namespace Balta.Payment.Services
{
    public class PaymentServices : IPaymentService
    {
        private string _gatewayName => GatewayHelper.GetGatewayName(Gateway);

        public EnumPaymentGateway Gateway { get; }

        public IPaymentProcessor Processor { get; }
        public IPaymentValidator Validator { get; }
        public IPaymentLogger Logger { get; }

        private PaymentServices(EnumPaymentGateway gateway) 
        {
            Processor = PaymentProcessor.Get(gateway);
            Validator = PaymentValidator.Get(gateway);
            Logger = PaymentLogger.Get(gateway);

            Gateway = gateway;
        }

        public void ProcessPayment(decimal amount, string cardNumber)
        {
            if (!Validator.ValidateCard(cardNumber))
            {
                Console.WriteLine($"{_gatewayName}: Cartão inválido");
                return;
            }

            string processResult = Processor.ProcessTransaction(amount, cardNumber);

            Logger.Log($"Transação Processada: {processResult}");
        }

        public static IPaymentService Get(EnumPaymentGateway gateway) 
            => new PaymentServices(gateway);
    }
}
