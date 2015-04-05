using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
//using System.Text.RegularExpressions.Regex;
using System.Text.RegularExpressions;
namespace ConsoleApplication5
{
    class Program
    {

        static void WriteIntoFile(string name, string id, string year , string template , string resultfile)
        {
            //replace template string
            string result = template.Replace("${中文姓名}",name);
             result = result.Replace("${身份證字號}", id);
             result = result.Replace("${年數}", year);
            // Console.WriteLine(result);
             using (StreamWriter writer = new StreamWriter(resultfile, true))
             {
                 writer.Write(result);
             }
        }

        static string handletemplatefile(string templatefile)
        {
            // open template file and transfer into a string  
            System.IO.StreamReader file = new System.IO.StreamReader(templatefile);
            string afterreplace = "";
            string line ; 
            while ((line = file.ReadLine()) != null)
            {
                line = String.Concat(line, "\r\n");  
                afterreplace = String.Concat(afterreplace,line);
            }
            file.Close();
            return afterreplace;
        }

        static void Main(string[] args)
        {
            // read and handle the template file

            // Console.WriteLine(args.Length);

            if (args.Length != 6)
            {
                Console.WriteLine("commad error");
            }
            else
            {
                string datainput = args[1];
                string templatefile = args[3];
                string resultfile = args[5];

                string template = handletemplatefile(templatefile);

                // clear the result file 
                File.WriteAllText(resultfile, string.Empty);

                //read data file 

                System.IO.StreamReader ReadData =
                new System.IO.StreamReader(datainput);
                string line;
                bool first = false;
                string[] data = new string[6];
                int counter = 0;
                while ((line = ReadData.ReadLine()) != null)
                {
                    if (first == false)
                    {
                        first = true;
                    }
                    else
                    {
                        Regex regex = new Regex("(\t)");
                        counter = 0;
                        foreach (string result in regex.Split(line))
                        {
                            data[counter] = result;
                            //  Console.WriteLine(data[counter]);
                            counter++;


                        }
                        string name = data[0];
                        string id = data[2];
                        string year = data[4];

                        //write to file 
                        WriteIntoFile(name, id, year, template, resultfile);
                    }
                }
               // Console.ReadLine();
            }
        }
    }
}
