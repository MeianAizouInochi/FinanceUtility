using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceSheetUpdater
{
    public class ProgramLoop
    {
        /*
         * Constructor that calls the actual business Logic.
         */
        public ProgramLoop() 
        {
            StartLoop();
        }

        /*
         * Code containing the Business Logic.
         */
        private void StartLoop()
        {
            bool Continue = true;

            Console.WriteLine("*************Welcome to Financial Utility Application.***************");

            Console.WriteLine("\n Now data can be added to the File.\n Use the Following Options to Control your Flow:\n");

            Console.WriteLine(" Option:");
            
            Console.WriteLine(" Enter C when Prompted if you want to continue.");
            
            Console.WriteLine(" Enter -1 to Exit anytime.");
            
            Console.WriteLine(" Enter Appropiate values for Required Fields.");
            
            Console.WriteLine("\n Press Enter to Continue:");
            
            Console.ReadLine();
            
            do
            {
                string? userInputContinue = null;

                while (userInputContinue == null || userInputContinue.Equals(""))
                {
                    userInputContinue = Console.ReadLine();
                }

                if (userInputContinue.Equals("C") || userInputContinue.Equals("c"))
                {
                    Console.WriteLine("Debug1");
                }
                else 
                {
                    Console.WriteLine("Debug2");
                }
                Console.WriteLine("Do you want to Continue: ");
            }
            while (Continue);

            Console.WriteLine("Program will Exit Now.");
           

        }
    }
}
