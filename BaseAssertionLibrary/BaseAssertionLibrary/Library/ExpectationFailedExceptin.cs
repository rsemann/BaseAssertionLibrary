using System;

namespace Unit
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
