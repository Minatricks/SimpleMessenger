using System;

namespace Chat.Exceptions
{
    public class NoPermissionsException : Exception
    {
        public NoPermissionsException(string message) : base(message) { }
    }
}
