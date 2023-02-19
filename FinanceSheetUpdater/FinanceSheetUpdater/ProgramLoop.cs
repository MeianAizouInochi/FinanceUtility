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
            /*
             * Boolean value to control the Loop.
             */
            bool Continue = true;

            DataInputTemplate obj;
            /*
             * Introductory Helper Lines.
             */
            Console.WriteLine("*************Welcome to Financial Utility Application.***************");

            Console.WriteLine("\n Now data can be added to the File.\n Use the Following Options to Control your Flow:\n");

            Console.WriteLine(" Option:");
            
            Console.WriteLine(" Enter C when Prompted if you want to continue.");
            
            Console.WriteLine(" Enter -1 to Exit anytime.");
            
            Console.WriteLine(" Enter Appropiate values for Required Fields.");
            
            Console.WriteLine("\n Press Enter to Continue:");
            
            Console.ReadLine();
            
            /*
             * Start of the Loop.
             */
            do
            {
                /*
                 * Required variables.
                 */
                string? Item_Name, Item_Class;
                
                double Item_Amount =0.0D, Credit=0.0D, Debit =0.0D;

                /*
                 * Item_Name Input and Verification.
                 */
                Console.Write("Provide the Item Name, Any Special Character will be ignored:");
                
                Item_Name= Console.ReadLine();

                while( Item_Name == null || Item_Name.Equals(""))
                {
                    Item_Name = Console.ReadLine();
                }
                
                if (Item_Name.Equals("-1"))
                {
                    break;
                }

                /*
                 * Item_Class Input and Verification
                 */
                Console.Write("Provide the Item Class, Any Special Character will be ignored:"); //Take Item_Class

                Item_Class= Console.ReadLine();

                while (Item_Class == null || Item_Class.Equals(""))
                {
                    Item_Class = Console.ReadLine();
                }
                if (Item_Class.Equals("-1"))
                {
                    break;
                }

                /*
                 * Item Amount Input and Verification.
                 */
                Console.Write("Provide the Item Amount:"); //Take Item_Amount

                bool temp = false;

                do
                {
                    try
                    {
                        Item_Amount = Convert.ToDouble(Console.ReadLine());

                        temp = false;
                    }
                    catch (Exception e)
                    {
                        temp = true;
                    }

                    if (Item_Amount==0.0D)
                    {
                        temp = true;
                    }
                }
                while (temp);

                if (Item_Amount == -1.0D)
                {
                    break;
                }


                /*
                 * Credit Amount Input and Verification.
                 */
                Console.Write("Provide the Credit Amount:");

                temp = false;

                //This Loop will continue, untill any valid input for the Credit is Provided.
                do
                {
                    try
                    {
                        Credit = Convert.ToDouble(Console.ReadLine());

                        temp = false;
                    }
                    catch (Exception e)
                    {
                        temp = true;
                    }
                }
                while (temp);

                if (Credit == -1.0D)
                {
                    break;
                }

                /*
                 * Debit Amount Input and Verification.
                 */
                Console.Write("Provide the Debit Amount:");

                temp = false;
                //This Loop will continue, untill any valid input for the Debit is Provided.
                do
                {
                    try
                    {
                        Debit = Convert.ToDouble(Console.ReadLine());

                        temp = false;
                    }
                    catch (Exception e)
                    {
                        temp = true;
                    }
                }
                while (temp);

                if (Debit == -1.0D)
                {
                    break;
                }


                /*
                 * Preparing the strings, so that no unnecessary delimiter is present.
                 */
                Item_Name.Replace(",", "");
                Item_Class.Replace(",","");


                /*
                 * Since We have prepared all Inputs,
                 * Calling Add on DataInputTemplate Object will Add the details to the specified file.
                 */

                try
                {
                    obj = new DataInputTemplate(Item_Name, Item_Class, Item_Amount, Credit, Debit);

                    Console.WriteLine("Press Enter to Add the Data to File:");

                    Console.ReadLine();

                    obj.Add();

                    Thread.Sleep(1000);

                }
                catch (Exception e) 
                {
                    Console.WriteLine(e.ToString());
                    Console.WriteLine("Error!");
                }
               
                Console.WriteLine("Do you want to Continue: ");

                string? Ans = Console.ReadLine();

                while (Ans == null || (!Ans.Equals("C") && !Ans.Equals("c") && !Ans.Equals("-1")))
                {
                    Ans = Console.ReadLine();
                }

                if (Ans.Equals("-1"))
                {
                    Continue = false;
                }
                else 
                {
                    Continue = true;
                }


            }
            while (Continue);


            //Add the last line of .csv file here.

            obj = new DataInputTemplate("Current Balance", "Balance", 1, DataInputTemplate.CurrentBalance, 0);

            obj.Add();

            Console.WriteLine("Program will Exit Now.");
           

        }
    }
}
