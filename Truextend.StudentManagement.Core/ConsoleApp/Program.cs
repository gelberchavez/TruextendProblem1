using System;
using System.Configuration;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Truextend.StudentManagement.Core.Bussiness;
using System.Data;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Start...");// prueba actualizacion mensaje vs2019
            Console.WriteLine("------------------------------------");
            Console.WriteLine("...Import of records from CSV File ...");
            //Call to method
            ImportStudentsCSV();
            //Call to method for list students
            Console.WriteLine("...Call to method for to get Stundets ...");
            ListStudents();
            Console.WriteLine("Press any key to exit!!!!!");
            Console.ReadKey();
        }
        #region Methods
        // Method to import records from the  CSV file
        private static void ImportStudentsCSV()
        {   //Recover CSV file path 
            string sruta = System.Configuration.ConfigurationManager.AppSettings["RutaFile"];

            string[] lines = File.ReadAllLines(sruta);
            string PreMessage = "ConsoleApp.exe input.csv ";
            foreach (var line in lines)
            {
                //Separate comma values, for each line
                var values = line.Split(',');
                //Instance the object
                clsStudent oStudent = new clsStudent();
                bool sw;
                // Use the object method to Insert 
                sw = oStudent.AddStudent(values[0].ToString(), values[1].ToString(), values[2].ToString(), FormatDate(values[3].ToString()));

                if (sw)
                {
                    Console.WriteLine(PreMessage + "name=" + values[1].ToString());// name
                    Console.WriteLine(PreMessage + "type=" + values[0].ToString());// type
                    string sGender= (values[2].ToString()=="F") ? "female" : "male";
                    Console.WriteLine(PreMessage + "gender=" + sGender);// gender
                    Console.WriteLine("Registered line... ");
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
        }
        //Method for format Datetimestamp
        public static DateTime FormatDate(string pStringDateFormatCSV)
        {
            DateTime ReturnDate;
            int formatYYYY = Convert.ToInt32(pStringDateFormatCSV.Substring(0, 4));//Year
            int formatMM = Convert.ToInt32(pStringDateFormatCSV.Substring(4, 2));//Month
            int formatDD = Convert.ToInt32(pStringDateFormatCSV.Substring(6, 2));//Day
            int formatHH = Convert.ToInt32(pStringDateFormatCSV.Substring(8, 2));//Hour
            int formatmm = Convert.ToInt32(pStringDateFormatCSV.Substring(10, 2));//Minute
            int formatSS = Convert.ToInt32(pStringDateFormatCSV.Substring(12, 2));//Second
            ReturnDate = new DateTime(formatYYYY, formatMM, formatDD, formatHH, formatmm, formatSS);
            return ReturnDate;// Returns the required date format
        }

        //Method for get Students
        public static void ListStudents()
        {
            clsStudent oStudent = new clsStudent();
            var vDataStudents = oStudent.GetStudentsSortedName();

            Console.WriteLine("-----Students List sorted by name-----");
            int count = 0;
            foreach (DataRow datarow in vDataStudents.Rows)
            {
                count++;
                Console.WriteLine("***************** Record " + count + "********************");
                Console.WriteLine(datarow[0].ToString() + " " + datarow[1].ToString() + " " + datarow[2].ToString() + " " + datarow[3].ToString() + " " + datarow[4].ToString());
            }


        }

        #endregion
    }

}
