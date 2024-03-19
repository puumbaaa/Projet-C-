// See https://aka.ms/new-console-template for more information


namespace test
{
    class Program
    {

        static readonly string textFile = "C:\\Users\\gbravin\\source\\repos\\Porjet C#\\Map\\map.txt";


        static void Main(string[] args)
        {
            if (File.Exists(textFile))
            {
                // Read entire text file content in one string
                string text = File.ReadAllText(textFile);
                Console.WriteLine(text);
            }
            while (true) { }
        }
    }
}
    