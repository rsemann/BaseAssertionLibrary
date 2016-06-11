using Unit.Library;

namespace Unit
{
    public static class AssertExtensions
    {
        public static IAssert Expect(this object value)
        {
            return new Assert(value);
        }
    }
}
