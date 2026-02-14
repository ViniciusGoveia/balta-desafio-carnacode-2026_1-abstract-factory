using Balta.Payment.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Balta.Payment.Interfaces.Logger
{
    public interface IPaymentLogger
    {
        public EnumPaymentGateway Gateway { get; }

        /// <summary>
        /// Submit a log record with a given message.
        /// </summary>
        /// <param name="message">The log message to be submitted.</param>
        public void Log(string message);
    }
}
