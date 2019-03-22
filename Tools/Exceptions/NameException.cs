using System;

namespace Csharp_laba2.Tools
{
    internal class NameException : Exception
    {
        private string _message;

        public override string Message
        {
            get => _message;
        }

        public NameException(string message)
        {
            _message = message;
        }
    }
}
