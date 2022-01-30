using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
namespace zooiiscool
{
    class ResourceManager
    {

        //aaaaaaaaaaa
        public static Dictionary<string, Sprite> sprites = new Dictionary<string, Sprite>();//aaa




        //fuck fuck shit stop wathcing me aaaaaaa
        public static Sprite RequestSprite(string name)
        {
            
            Sprite output;

            if(!sprites.ContainsKey(name))
            {
                var texture = new Texture(name);
                var sprite = new Sprite(texture);
                sprite.Origin = new SFML.System.Vector2f((float)(sprite.Texture.Size.X / 2), (float)(sprite.Texture.Size.Y / 2));
                sprites.Add(name, sprite);
                return sprite;
                
            }
            return sprites[name];
            //zoooi 

        }
    }
}
