using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M4_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var SimpleMath = new Calc();
            double n1 = GetUserConsoleDouble("Please, enter first double number:");
            double n2 = GetUserConsoleDouble("Please, enter second double number:");
            int op = GetOperationType("Please, enter operation type:", SimpleMath);           
            
            Console.WriteLine("Result = " + SimpleMath[op].Calc.Invoke(n1, n2));
        }

        /// <summary>
        /// Get double number which enter user in console
        /// </summary>
        /// <param name="messege">Text of message which see user before enter double number</param>
        /// <returns>Double number which enter user in console</returns>
        private static double GetUserConsoleDouble(string message)
        {
            double num = Double.NaN;
            bool isEnterNum = true;

            Console.WriteLine(message);
            while (isEnterNum)
            {
                try
                {
                    num = double.Parse(Console.ReadLine());
                    isEnterNum = false;
                }
                catch (Exception)
                {
                    Console.WriteLine("Sorry, number which you enter have not correct format or value. Please, try again.");
                }
            }

            return num;
        }

        /// <summary>
        /// Get index of mathemetic operation which enter user in console
        /// </summary>
        /// <param name="message">Text of message which see user before enter index of operation</param>
        /// <param name="SimpleCalc">class which storage mathematic type of operation</param>
        /// <returns>index of mathemetic operation which enter user in console</returns>
        private static int GetOperationType(string message, Calc SimpleCalc)
        {
            int num = Int32.MinValue;
            bool isEnterNum = true;

            Console.WriteLine(message);
            Console.WriteLine("Enter number, which associated with operation type");
            for (int i = 0; i < SimpleCalc.Count; i++)
            {
                Console.WriteLine(i + " - " + SimpleCalc[i].Type);
            }

            while (isEnterNum)
            {
                try
                {
                    num = int.Parse(Console.ReadLine());
                    if (SimpleCalc.IsCorrectIndexOperation(num))
                        isEnterNum = false;
                    else
                        throw new FormatException();
                }
                catch (Exception)
                {
                    Console.WriteLine("Sorry, number which you enter have not correct format or value. Please, try again.");
                }
            }

            return num;
        }

        
    }
}
