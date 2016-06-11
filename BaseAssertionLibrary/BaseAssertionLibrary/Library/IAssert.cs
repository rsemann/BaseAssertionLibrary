namespace Unit.Library
{
    public interface IAssert
    {
        void Eq(object obj);
        void IsGreater(object obj);
        IAssert Not();
    }
}
