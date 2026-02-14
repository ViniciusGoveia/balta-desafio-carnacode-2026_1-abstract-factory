using Balta.Payment.Interfaces.Services;
using Balta.Payment.Model.Enums;
using Balta.Payment.Services;

Console.WriteLine("=== Sistema de Pagamentos ===\n");

IPaymentService pagSeguroService = PaymentServices.Get(EnumPaymentGateway.PagSeguro);
pagSeguroService.ProcessPayment(150.00m, "1234567890123456");

Console.WriteLine();

IPaymentService mercadoPagoService = PaymentServices.Get(EnumPaymentGateway.MercadoPago);
mercadoPagoService.ProcessPayment(200.00m, "5234567890123456");

Console.WriteLine();
