using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ConsoleApplication5
{
    class Program
    {

        static void ChangeText(string name, string id, string year)
        {
            
        }

        static void Main(string[] args)
        {
            int counter = 0;
            string line;

            // Read the file and display it line by line.
            System.IO.StreamReader file =
               new System.IO.StreamReader("./template.txt");
            string afterreplace = "";
            while ((line = file.ReadLine()) != null)
            {
                counter=0;

              //  string afterreplace =line.Replace("${中文姓名}", );


                Console.WriteLine(line);
                afterreplace = String.Concat(afterreplace, line); 
                  


            }
            Console.WriteLine(afterreplace);
                      // Console.WriteLine("get");

                
            file.Close();

            // Suspend the screen.
            Console.ReadLine();
        }
    }
}
