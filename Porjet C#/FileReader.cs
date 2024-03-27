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


        public void setFile(string file)
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
    }
}
