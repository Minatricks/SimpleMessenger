using System;
using System.Collections.Generic;

namespace Chat.Exceptions
{
    public abstract class IncorrectParametersException : Exception
    {
        protected IncorrectParametersException(string message, params object[] args) : base(message)
        {
            Parameters = new List<object>();
            Parameters.AddRange(args);
        }

        public List<object> Parameters { get; }
    }
}
