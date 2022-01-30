using System;
using System.Collections.Generic;
using System.Text;
using SFML.Window;
namespace zooiiscool
{
    class Input
    {

        //todo: use floating point axis like in Unity so I don't have to make spaghetti code for movemnt OwO

        static Dictionary<string, Keyboard.Key> keys = new Dictionary<string, Keyboard.Key>();

        public static void RegisterKey(string name, Keyboard.Key key)
        {
            keys.Add(name, key);
        }

        public static bool IsKeyDown(string name)
        {
            //will crash if you use an incorrect key name, so don't <3
            return SFML.Window.Keyboard.IsKeyPressed(keys[name]);
        }
    }
}
