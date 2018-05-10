using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M4_Calculator
{
    public class Calc
    {
        private Dictionary<int, Operation> operationCalc;
        public struct Operation
        {
            public string Type { get; set; }
            public OperationHandler Calc { get; set; }
        }

        public delegate double OperationHandler(double a, double b);

        public Calc()
        {
            operationCalc = new Dictionary<int, Operation>();
            operationCalc[0] = new Operation() { Type = "Sum", Calc = delegate (double a, double b) { return a + b; } };
            operationCalc[1] = new Operation() { Type = "Difference", Calc = delegate (double a, double b) { return a - b; } };
            operationCalc[2] = new Operation() { Type = "Multiplication", Calc = (a, b) => a * b };
            operationCalc[3] = new Operation(){Type = "Division", Calc = (a, b) => a / b };
        }

        public Operation this[int i]
        { 
            get
            {
                return operationCalc[i];
            }
        }

        public int Count
        {
            get
            {
                return operationCalc.Count;
            }
        }

        public bool IsCorrectIndexOperation(int index)
        {
            return operationCalc.ContainsKey(index);
        }
    }
}
