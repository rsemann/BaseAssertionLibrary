using System;
using Unit.Library;

namespace Unit
{
    public class Assert : IAssert
    {
        private readonly object _value;
        private bool _isNot;
        private bool _isPropertyNameEqual;

        /// <summary>
        /// It's initialized the object reference of the assertions
        /// </summary>
        /// <param name="value">Reference object</param>
        public Assert(object value)
        {
            _value = value;
            _isNot = false;
        }

        /// <summary>
        /// Compares one object to the other
        /// </summary>
        /// <param name="obj">Object to be compared with the initial value</param>
        public void Eq(object obj)
        {
            var typeValue = _value.GetType();
            if (typeValue.GetProperties().Length > 0) //Reference types
            {
                var typeObj = obj.GetType();
                foreach (var propertyValue in typeValue.GetProperties())
                {
                    bool hasEqualName = false;

                    foreach (var propertyObj in typeObj.GetProperties())
                    {
                        if (propertyValue.Name.Equals(propertyObj.Name))
                        {
                            Compare(propertyValue.GetValue(_value, null), propertyObj.GetValue(obj, null));
                            hasEqualName = true;
                            break;
                        }
                    }

                    if (_isPropertyNameEqual && !hasEqualName)
                        throw new ExpectationFailedExceptin("Properties name does not match");
                }
            }
            else //Value types
                Compare(_value, obj);
        }

        /// <summary>
        /// Generic method to compare values between objects
        /// </summary>
        /// <param name="value"></param>
        /// <param name="obj"></param>
        private void Compare(object value, object obj)
        {
            if (_isNot && value.Equals(obj))
                throw new ExpectationFailedExceptin(string.Format("{0} and {1} are equals", value, obj));

            if (!_isNot && !value.Equals(obj))
                throw new ExpectationFailedExceptin(string.Format("Expected: {0}, Found {1}", value, obj));
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

        /// <summary>
        /// Invert assertion result
        /// </summary>
        /// <returns>Own instance</returns>
        public IAssert Not()
        {
            _isNot = !_isNot;
            return this;
        }

        /// <summary>
        /// Check if method throws an exception of given type
        /// </summary>
        public void RaiseError()
        {
            bool hasThrownError = false;

            try
            {
                Action action = _value as Action;
                action();
            }
            catch
            {
                hasThrownError = true;
            }

            if (!hasThrownError)
                throw new ExpectationFailedExceptin("Exception has not been thrown.");
        }

        /// <summary>
        ///  Apply assertions on object's properties values matched by name with second object. 
        /// (expected type can be different than tested type)
        /// </summary>
        /// <returns></returns>
        public IAssert Properties()
        {
            _isPropertyNameEqual = true;
            return this;
        }
    }
}
