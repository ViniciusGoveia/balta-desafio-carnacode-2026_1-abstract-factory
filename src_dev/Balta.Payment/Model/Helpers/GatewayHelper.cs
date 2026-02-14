using Balta.Payment.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Balta.Payment.Model.Helpers
{
    public static class GatewayHelper
    {
        public static string GetGatewayName(EnumPaymentGateway gateway)
        {
            return gateway switch
            {
                EnumPaymentGateway.PagSeguro => "PagSeguro",
                EnumPaymentGateway.MercadoPago => "Mercado Pago",
                EnumPaymentGateway.Stripe => "Stripe",
                _ => "Unknown"
            };
        }
    }
}
