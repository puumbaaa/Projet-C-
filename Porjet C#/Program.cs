// See https://aka.ms/new-console-template for more information

using Mapp;
namespace test
{
    class Program
    {

    

        static void Main(string[] args)
        {

            
            FileReader map = new FileReader();
            map.setFile();
            Console.WriteLine(map.sText);
            Console.SetCursorPosition(0, 0);
            Console.SetBufferSize(120, 30);
            while (true) { }
        }
    }
}
    