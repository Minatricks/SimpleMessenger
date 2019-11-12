using System;

namespace Chat.Exceptions
{
    public abstract class NoPermissionsException : Exception
    {
        protected NoPermissionsException(string message) : base(message) { }
    }
}
