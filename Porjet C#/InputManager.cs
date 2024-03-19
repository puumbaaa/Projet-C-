using System;
using System.Collections.Generic;

namespace Input
{
    enum KeyState { Press, Up, Down, NoPress };

    class InputManager
    {
        private List<ConsoleKey> keys = new List<ConsoleKey>();
        private List<KeyState> keyStates = new List<KeyState>();

        public void Init(List<ConsoleKey> inputKeys)
        {
            keys = inputKeys;
            keyStates = new List<KeyState>(new KeyState[keys.Count]);
        }

        public void Update(ConsoleKeyInfo keyInfo)
        {
            if (keyInfo != null) {
                for (int i = 0; i < keys.Count; i++)
                {

                    KeyState currentState = keyStates[i];

                    if (keyInfo.Key == keys[i])
                    {
                        if (currentState == KeyState.Down || currentState == KeyState.Press)
                            keyStates[i] = KeyState.Press;
                        else
                            keyStates[i] = KeyState.Down;
                    }
                    else
                    {
                        if (currentState == KeyState.Up || currentState == KeyState.NoPress)
                            keyStates[i] = KeyState.NoPress;
                        else
                            keyStates[i] = KeyState.Up;
                    }
                }
            }
            
        }

        public bool IsKey(ConsoleKey key)
        {
            int index = keys.IndexOf(key);
            if (index != -1)
            {
                return keyStates[index] == KeyState.Press || keyStates[index] == KeyState.Down;
            }
            return false;
        }
    }
}
