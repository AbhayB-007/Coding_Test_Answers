using CodingTest_Application.IRepository;

namespace CodingTest_Application.Repository
{
    public class commonClass : IcommonClass
    {
        public int callFunction(string param, int x, int y)
        {
            int result = 0;
            myFunctions myFunctions = new myFunctions();
            if (param.Equals("Add", StringComparison.OrdinalIgnoreCase)) 
            {
                result = myFunctions.function1(x, y);
            }
            else if(param.Equals("Multiply", StringComparison.OrdinalIgnoreCase))
            {
                result = myFunctions.function2(x, y);
            }
            return result;
        }
    }

    public class myFunctions
    {
        public int function1(int x, int y)
        {
            return (x + y);
        }
        public int function2(int x, int y)
        {
            return (x * y);
        }
    }
}
