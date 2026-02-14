using Balta.Payment.Interfaces.Processor;
using Balta.Payment.Model.Enums;
using Balta.Payment.Model.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Balta.Payment.Model.Processor
{
    public class PaymentProcessor : IPaymentProcessor
    {
        public EnumPaymentGateway Gateway { get; }

        private PaymentProcessor(EnumPaymentGateway gateway) 
            => Gateway = gateway;

        public string ProcessTransaction(decimal amount, string cardNumber)
        {
            return Gateway switch
            {
                EnumPaymentGateway.PagSeguro => ProcessPagSeguroTransaction(amount, cardNumber),
                EnumPaymentGateway.MercadoPago => ProcessMercadoPagoTransaction(amount, cardNumber),
                EnumPaymentGateway.Stripe => ProcessStripeTransaction(amount, cardNumber),
                _ => throw new NotImplementedException("This gateway is not implemented yet.")
            };
        }

        private string ProcessPagSeguroTransaction(decimal amount, string cardNumber)
        {
            Console.WriteLine($"{GatewayHelper.GetGatewayName(Gateway)}: Processando R$ {amount}...");
            return $"PAGSEG-{Guid.NewGuid().ToString()[..8]}";
        }

        private string ProcessMercadoPagoTransaction(decimal amount, string cardNumber)
        {
            Console.WriteLine($"{GatewayHelper.GetGatewayName(Gateway)}: Processando R$ {amount}...");
            return $"MP-{Guid.NewGuid().ToString()[..8]}";
        }

        private string ProcessStripeTransaction(decimal amount, string cardNumber)
        {
            Console.WriteLine($"{GatewayHelper.GetGatewayName(Gateway)}: Processando ${amount}...");
            return $"STRIPE-{Guid.NewGuid().ToString()[..8]}";
        }

        public static IPaymentProcessor Get(EnumPaymentGateway gateway) 
            => new PaymentProcessor(gateway);
    }
}
