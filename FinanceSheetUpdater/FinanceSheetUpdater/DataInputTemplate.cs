using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceSheetUpdater
{
    /*
     * There needs to be a backup file created everytime the Program/App runs,
     * to prevent loss of data in case of error.
     * There is also a need to expose a different file to the user for their use, instead of the file that would be used by the application.
     * Hence, a duplicate file needs to be created for the user to use.
     * 
     * Total files: 3
     * 1. File used by the Application.
     * 2. File kept as Backup.
     * 3. File Exposed to the user.
     * 
     * Logic for duplicate file:
     * -----------------------------------------------------------------
     * When The Program starts, create a backup. [Backup file creation.]
     * 
     * When the program ends Create a copy of the file used by the application and provide it to User.
     * 
     */
    public class DataInputTemplate
    {

        /*
         * Path of the Output .csv File. [Made static so it can be accessed from outside the class without having to depend on creating an instance.]
         */
        public static string OutputPath = @"\FinancialDataSheet.csv";


        /*
         * The Current Balance. [This is changed by the static constructor right at the beginning of the life cycle of the first instance.]
         */
        public static double CurrentBalance { get; set; } = 0.0D;

        /*
         * debit and Debit, as private field and its exposed version.
         */
        private double debit;

        public double Debit
        {
            get { return debit; }

            set 
            {
                if (value > CurrentBalance)
                {
                    throw new Exception("Your Debit Exceeds the Current Balance!!");
                }
                else
                {
                    CurrentBalance -= value;

                    debit = value;
                }
            }
        }


        /*
         * credit and Credit as the private and its Exposed Version.
         */
        private double credit;

        public double Credit
        {
            get { return credit; }

            set 
            {
                CurrentBalance+= value;

                credit = value;
            }
        }

        /*
         * Properties containing information on the transaction.
         * 
         * Item Name
         * Item Class
         * Item Amount
         */
        public string Item_Name { get; set; } = "";

        public string Item_Class { get; set; } = "";

        public double? Item_Amount { get; set; }

        /*
         * Static constructor to update Current Balance.
         */        
        static DataInputTemplate() 
        {
            if (File.Exists(OutputPath))
            {
                /*
                 * Since The File Exists, then the Last Line of the File needs to get loaded, and parsed to store the Current Balance inside the CurrentBalance field.
                 * 
                 * Logic of Read Last Line GOes here.
                 */
            }
            else 
            {
                /*
                 * Since the File doesnt Exist, then this would be the first entry.
                 * Hence, no need to update the Current Balance field.
                 * Since, it will be added when the first constructor is called for credit,
                 * else it will throw an error for debit if Current Balance is still 0.
                 */
                using (StreamWriter sw = new StreamWriter(OutputPath, true)) 
                {
                    /*
                     * Adding the Headings to the First Line of the .csv File.
                     */
                    sw.WriteLine("Item Name,Item Class,Item Amount,Credit,Debit");

                    sw.Flush();

                    sw.Close();
                }

                Console.WriteLine("File did not Exist.\nFile Was Created and necessary changes were made.");
            }
        }

        /*
         * The constructor to Provide the data for the transaction.
         */
        public DataInputTemplate(string Item_Name, string Item_Class, double Item_Amount, double Credit = 0.0D, double Debit = 0.0D)
        {
            this.Credit= Credit;

            this.Debit= Debit;

            this.Item_Name= Item_Name;

            this.Item_Amount= Item_Amount;

            this.Item_Class= Item_Class;

        }

        /*
         * Add function.
         * THis Adds the data to the file.
         */
        public int Add() 
        {
            int Result = 0;

            try
            {
                using (StreamWriter sw = new StreamWriter(OutputPath, true))
                {
                    sw.WriteLine(Item_Name+","+ Item_Class + "," + Item_Amount + "," + credit + "," + debit);

                    sw.Flush();

                    sw.Close();
                }
                
            }
            catch (Exception e)
            {
                Result = -1;
                Console.WriteLine(e.ToString());
                Console.WriteLine("Error Occured During writting to FinancialDataSheet File!!");
            }
            finally 
            {
                Console.WriteLine("\nInitiated Operation has been Completed.\n");
            }

            return Result;
        }
         
    }
}
