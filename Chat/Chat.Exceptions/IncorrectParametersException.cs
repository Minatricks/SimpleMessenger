using System;
using System.Collections.Generic;

namespace Chat.Exceptions
{
    public class IncorrectParametersException : Exception
    {
        public IncorrectParametersException(string message, params object[] args) : base(message)
        {
            Parameters = new List<object>();
            Parameters.AddRange(args);
        }

        public List<object> Parameters { get; }
    }
}
