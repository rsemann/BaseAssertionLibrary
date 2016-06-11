using System;
using Unit.Library;

namespace Unit
{
    public class Assert : IAssert
    {
        private readonly object _value;

        /// <summary>
        /// It's initialized the object reference of the assertions
        /// </summary>
        /// <param name="value">Reference object</param>
        public Assert(object value)
        {
            _value = value;
        }

        /// <summary>
        /// Compares one object to the other
        /// </summary>
        /// <param name="obj">Object to be compared with the initial value</param>
        public void Eq(object obj)
        {
            if (!_value.Equals(obj))
                throw new ExpectationFailedExceptin(string.Format("Expected: {0}, Found {1}", _value, obj));
        }

        /// <summary>
        ///  Check if one object is greater than the other
        /// </summary>
        /// <param name="obj">Object to verify</param>
        public void IsGreater(dynamic obj)
        {
            if (Convert.ToDecimal(_value) < Convert.ToDecimal(obj))
                throw new ExpectationFailedExceptin(string.Format("Value {0} smaller than {1}", _value, obj));
        }
    }
}
