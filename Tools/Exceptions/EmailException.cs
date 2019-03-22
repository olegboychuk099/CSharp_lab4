using System;

namespace Csharp_laba2.Tools
{
    internal class EmailException : Exception
    {
        private string _message;

        public override string Message
        {
            get => _message;
        }

        public EmailException(string message)
        {
            _message = message;
        }
    }
}
