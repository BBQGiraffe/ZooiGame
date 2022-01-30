using System;
using System.Collections.Generic;
using System.Text;
using SFML.Audio;
namespace zooiiscool
{
    class Audio
    {
        //todo: load sound definitions from file or some shid UwU


        static Dictionary<string, Sound> sounds = new Dictionary<string, Sound>();

        

        public static Sound RequestSound(string name)
        {
            if (sounds.ContainsKey(name))
            {
                return sounds[name];
            }
            sounds.Add(name, new Sound(new SoundBuffer(name)));
            return sounds[name];
        }

        public static void PlaySound(string name, bool loop, float volume = 50f)
        {
            Sound sound = RequestSound(name);
            sound.Loop = loop;
            sound.Volume = volume;
            sound.Play();
    
       
        }
    }
}
