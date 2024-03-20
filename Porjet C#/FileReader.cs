using Mapp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapp
{
    class FileReader : Map
    {

        string m_sText;

        public string sText
        {
            get => m_sText;
            set => m_sText = value;
        }

        public int GetLineCount(string file)
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


        public void SetFile(string file)
        {
            if (File.Exists(file))
            {
                // Read entire text file content in one string
                m_sText = File.ReadAllText(file);
            }
        }

        public void printFile()
        {
            Console.WriteLine(sText);
        }

        public void PrintFileLine(string file, int line)
        {
            string m_sText = File.ReadLines(file).Skip(line).Take(1).First();
            Console.WriteLine(m_sText);

        }


    } // End of class
}