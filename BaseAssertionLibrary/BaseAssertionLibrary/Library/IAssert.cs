using System;
using Unit.Tests;

namespace Unit.Library
{
    public interface IAssert
    {
        void Eq(object obj);
        void IsGreater(object obj);
        IAssert Not();
        void RaiseError();
        IAssert Properties();
        IAssert PropertiesWithout(Func<dynamic, object> property);
    }
}
