namespace Calculator
{
    public interface ICalculator
    {
        void Add(int number);
        int DoOperation(Operation op);
        int[] GetNumbersOnStack();
    }
}