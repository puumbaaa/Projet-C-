using Mapp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Mapp
{
    class FileReader : Map
    {

        string m_sText;

        public string sText
        {
            get => m_sText;
            private set => m_sText = value;
        }


        public int GetFileLineCount(string file)
        {
            if (File.Exists(file))
            {
                return File.ReadLines(file).Count();
            }
            else
            {
                return 0;
            }
        }
        public int GetTextLineCount()
        {
            return m_sText.Split('\n').Length +1;
        }

        public void SetFile(string file)
        {
            if (File.Exists(file))
            {
                // Read entire text file content in one string
                m_sText = File.ReadAllText(file);
            }
        }

        public void PrintFile()
        {
            Console.WriteLine(sText);
        }

        public void PrintFileLine(string file, int line)
        {
            Console.WriteLine(
                File.ReadLines(file).Skip(line).Take(1).First()
                );
            
        }

        public void PrintTextLine(int lineNumber)
        {
            var reader = new StringReader(m_sText);

            string line;
            int currentLineNumber = 0;

            do
            {
                currentLineNumber += 1;
                line = reader.ReadLine();
            }
            while (line != null && currentLineNumber < lineNumber);

            Console.WriteLine( (currentLineNumber == lineNumber) ? line :
                                                       string.Empty );

        }


    } // End of class
}