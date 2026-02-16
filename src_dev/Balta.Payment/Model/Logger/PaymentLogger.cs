using Balta.Payment.Abstractions.Logger;
using Balta.Payment.Model.Enums;
using Balta.Payment.Model.Helpers;

namespace Balta.Payment.Model.Logger
{
    public class PaymentLogger : IPaymentLogger
    {
        public EnumPaymentGateway Gateway { get; }

        private PaymentLogger(EnumPaymentGateway gateway) 
            => Gateway = gateway;

        public void Log(string message) 
            => Console.WriteLine($"[{GatewayHelper.GetGatewayName(Gateway)} Log] {DateTime.Now}: {message}");

        public static IPaymentLogger Get(EnumPaymentGateway gateway) 
            => new PaymentLogger(gateway);
    }
}
