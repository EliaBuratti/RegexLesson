using System.Text.RegularExpressions;

namespace RegexLesson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //First exmple how to validate emai

            string MyMail = "mariorossi89@example.com";

            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";

            bool isValid = Regex.IsMatch(MyMail, pattern);

            Console.WriteLine(isValid +"\n\n"); //true


            
            
            //Second example how to get first and second name

            string MyDetails = "Nome: Marco Cognome: Romboli";

            string patternDetails = @"Nome: (?<nome>\w+) Cognome: (?<cognome>\w+)";

            Match match = Regex.Match(MyDetails, patternDetails);

            if (match.Success) 
            {
                Console.WriteLine($"My name is: {match.Groups["nome"].Value} and my surname is: {match.Groups["cognome"]}");
            }
            else
            {
                Console.WriteLine("Nothing matching found.");
            }

            Console.WriteLine("\n\n");

            
            
            //third example how to manipulate a text

            string MyText = "<div>Questo è un <b>paragrafo</b> <span>con diversi tag</span></div>";

            string patternText = @"<[^>]+>";

            string result = Regex.Replace(MyText, patternText, "");

            Console.WriteLine(result);

            Console.WriteLine("\n\n");




            //fourth exampe how to transofm numbers in text

            string MyNum = "Nella dispensa ci sono 4 mele e 8 pere";

            string patternNum = @"\d+";


            string resultManipulation = Regex.Replace(MyNum, patternNum, transformNum);

            //in this case regex use automatically method added a match num

            Console.WriteLine(resultManipulation);

        }

        static string transformNum(Match match)
        {
            int num = int.Parse(match.Value);

            string[] word = new string[] { "zero", "uno", "due", "tre", "quattro", "cinque", "sei", "sette", "otto", "nove" };

            string result = "";

            while(num > 0)
            {
                int digit = num % 10;

                result = word[digit] + result;

                num /= 10;            
            }
        
            /*
                * in this example are usign for number > 10 
                * 
                * example: num = 10;
                * 
                * ------- inside a while loop -------
                * 
                * digit = 10(num) % 10 = 1
                * 
                * num = 10(num) / 10 = 1 
                *  
                * ------- second loop -------
                *  
                * digit = 1(num) % 10 = 0
                *  
                * num = 1(num) / 10 = 0.1 casted to int equals 0
                *  
                * exit the loop
                */

            return result.Trim();
        }
    }
}
