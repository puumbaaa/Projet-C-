using System;
using System.Collections.Generic;

namespace Input
{
    enum KeyState { Press, Up, Down, NoPress };

    public class InputManager
    {
        private List<ConsoleKey> _keys = new List<ConsoleKey>();
        private List<KeyState> _keyStates = new List<KeyState>();

        public void Init(List<ConsoleKey> inputKeys)
        {
            _keys = inputKeys;
            _keyStates = new List<KeyState>(new KeyState[_keys.Count]);
        }

        public void Update(ConsoleKeyInfo keyInfo)
        {
            if (keyInfo != null) {
                for (int i = 0; i < _keys.Count; i++)
                {

                    KeyState currentState = _keyStates[i];

                    if (keyInfo.Key == _keys[i])
                    {
                        if (currentState == KeyState.Down || currentState == KeyState.Press)
                            _keyStates[i] = KeyState.Press;
                        else
                            _keyStates[i] = KeyState.Down;
                    }
                    else
                    {
                        if (currentState == KeyState.Up || currentState == KeyState.NoPress)
                            _keyStates[i] = KeyState.NoPress;
                        else
                            _keyStates[i] = KeyState.Up;
                    }
                }
            }
            
        }

        public bool IsKey(ConsoleKey key)
        {
            int index = _keys.IndexOf(key);
            if (index != -1)
            {
                return _keyStates[index] == KeyState.Press || _keyStates[index] == KeyState.Down;
            }
            return false;
        }
    }
}
