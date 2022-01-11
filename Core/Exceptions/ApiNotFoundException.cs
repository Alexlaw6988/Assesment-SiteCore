using System;

namespace Core.Exceptions
{
    public class ApiNotFoundException : Exception
    {
        public ApiNotFoundException(string message) : base(message)
        {

        }
    }
}
