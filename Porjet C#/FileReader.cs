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
        readonly string m_sTextFile = "..\\..\\..\\..\\Map\\map.txt";

        string m_sText = "";

        public string sText
        {
            get => m_sText;
            private set => m_sText = value;
        }


        public void setFile()
        {
            if (File.Exists(m_sTextFile))
            {
                // Read entire text file content in one string
                 m_sText = File.ReadAllText(m_sTextFile);
            }
        }
    }
}
