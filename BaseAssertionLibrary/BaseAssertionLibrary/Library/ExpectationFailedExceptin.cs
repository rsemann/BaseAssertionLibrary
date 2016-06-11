using System;

namespace Unit.Library
{
    public class ExpectationFailedExceptin : Exception
    {
        public ExpectationFailedExceptin()
        {
        }

        public ExpectationFailedExceptin(string message)
            : base(message)
        {
        }

        public ExpectationFailedExceptin(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
