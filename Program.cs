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

        static void WriteIntoFile(string name, string id, string year , string template)
        {
            //replace template string
            string result = template.Replace("${中文姓名}",name);
             result = result.Replace("${身份證字號}", id);
             result = result.Replace("${年數}", year);
             Console.WriteLine(result);
             using (StreamWriter writer = new StreamWriter("AllTxtFiles.txt", true))
             {
                 writer.Write(result);
             }
        }

        static string handletemplatefile()
        {
            // open template file and transfer into a string  
            System.IO.StreamReader file = new System.IO.StreamReader("./template.txt");
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
            string template = handletemplatefile();
            
            // clear the result file 
            File.WriteAllText("AllTxtFiles.txt", string.Empty);

            //read data file 

            System.IO.StreamReader ReadData =
            new System.IO.StreamReader("data.txt");
            string line;
            bool first = false;
            string[] data = new string[6];
            int counter=0; 
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
                    WriteIntoFile(name, id, year,template); 

                    
                }
              
                

            }
           
            counter = 0;
            

           
       
          
                      // Console.WriteLine("get");

                
          

            // Suspend the screen.
            Console.ReadLine();
        }
    }
}
