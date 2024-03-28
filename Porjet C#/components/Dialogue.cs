using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Porjet_C_.components
{
    internal class Dialogue : Component
    {
        List<string> _dialogues;

        public List<string> Dialogues { get => _dialogues; set => _dialogues = value; }
        public Dialogue(string title) : base(title) 
        {
            Dialogues = new List<string>();
            string text = "Traveler, can you please fight the boss in the next room ?";
            Dialogues.Add(text);
            text = "To get there you need to find the key that opens the door.";
            Dialogues.Add(text);
            text = "You can find it in the grass";
            Dialogues.Add(text);
            text = "Good Luck";
            Dialogues.Add(text);

        }
    }
}
