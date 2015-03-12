using System;

namespace DeedSimple.DataAccess.Exceptions
{
    public abstract class DataAccessException : Exception
    {
        protected DataAccessException()
        {
            
        }

        protected DataAccessException(string message)
            : base(message)
        {

        }

        protected DataAccessException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
