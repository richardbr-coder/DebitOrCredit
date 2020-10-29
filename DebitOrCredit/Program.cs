using System;
using static System.Console;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebitOrCredit
{
    class Program
    {
        static void Main(string[] args)
        {
            const char DELIM = ',';
            const string filename = @"F:\School\CP1120 - Fundamentals of Programming I\Final\DebitOrCredit\AccountInformation.txt";

            int numb;
            string lastName;
            string firstName;
            decimal money;
            string debit = "Debit";
            string credit = "Credit";
            

            FileStream inFile = new FileStream(filename, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(inFile);

            string recordIn;
            string[] fields;

            WriteLine("   Account Information Program\n\n");

            // read the first line of the file
            recordIn = reader.ReadLine();

            // loop while there are still records in the file
            while (recordIn != null)
            {
                fields = recordIn.Split(DELIM);

                numb = Convert.ToInt32(fields[0]);
                lastName = fields[1];
                firstName = fields[2];
                money = Convert.ToDecimal(fields[3]);

                if (money < 0)
                {
                    WriteLine("{0,1}{1,1}{2,1}{3}{4,10}", numb + ",", lastName + DELIM, firstName + DELIM, "\t" + money + ",", "\t" + credit);
                }
                else if (money >= 0)
                {
                    WriteLine("{0,1}{1,1}{2,1}{3}{4,10}", numb + ",", lastName + DELIM, firstName + DELIM, "\t" + money + ",", "\t" + debit);
                }
                recordIn = reader.ReadLine();
            }
            reader.Close();
            inFile.Close();
        }
    }
}
