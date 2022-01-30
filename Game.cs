using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace zooiiscool
{
    class Game
    {
        static Scene CurrentScene;
        public static List<Entity> Entities = new List<Entity>();
        static Clock DeltaClock = new Clock();

        public static RenderWindow window;


        public static void LoadKeys()
        {
            //todo: load from file
            Input.RegisterKey("up", SFML.Window.Keyboard.Key.Up);
            Input.RegisterKey("down", SFML.Window.Keyboard.Key.Down);
            Input.RegisterKey("left", SFML.Window.Keyboard.Key.Left);
            Input.RegisterKey("right", SFML.Window.Keyboard.Key.Right);
            Input.RegisterKey("fire", SFML.Window.Keyboard.Key.Space);
        }

        static void OnClose(object sender, EventArgs e) {
            RenderWindow window = (RenderWindow)sender;
            window.Close();
        }


        public static void Init(string name, uint width, uint height)
        {
            window = new RenderWindow(new SFML.Window.VideoMode(width, height), name);
            window.SetFramerateLimit(120);
            LoadKeys();

            window.Closed += new EventHandler(OnClose);

            Audio.PlaySound("Music.wav", true, 5f);
            while (window.IsOpen)
            {
                Update();
                Render();
            }

        }

        static List<Entity> ToBeRemoved = new List<Entity>();


        static void Update()
        {
            Time.DeltaTime = DeltaClock.Restart().AsSeconds();//I shit and I fart
            Time.FrameCount++;
            Time.TimeSinceLoad += Time.DeltaTime;
            window.DispatchEvents();
            CurrentScene.Update();
            
            foreach(Entity entity1 in Entities)
            {
                foreach(Entity entity2 in Entities)
                {
                    if(entity1 != entity2)
                    {
                        if (Math.AABB(entity1, entity2))
                        {
                            entity1.OnCollision(entity2);
                            entity2.OnCollision(entity1);
                        }
                    }
                    
                }
            }

            //so it doesn't fucking crash;
            var size = Entities.Count;
            for(int i = 0; i < size; i++)
            {
                Entities[i].Update();
                if (!Entities[i].active)
                {
                    ToBeRemoved.Add(Entities[i]);
                }
                
            }

            foreach(Entity entity in ToBeRemoved)
            {
                Entities.Remove(entity);
            }
            ToBeRemoved.Clear();
          

        }

        public static void SetScene(Scene scene)
        {
            scene.Start();
            CurrentScene = scene;
        }

        static void Render()
        {
            window.Clear();
            foreach(Entity entity in Entities)
            {
                var sprite = ResourceManager.RequestSprite(entity.texture);
                sprite.Position =  new SFML.System.Vector2f(entity.position.X, entity.position.Y);

                //OwO
                entity.size = new System.Numerics.Vector2(sprite.Texture.Size.X, sprite.Texture.Size.Y);
                entity.center = entity.position;
                sprite.Rotation = entity.rotation;
                window.Draw(sprite);

            }
            CurrentScene.Render();
            window.Display();
        }

        static void LoadScene(Scene scene)
        {
            CurrentScene = scene;
        }




    }
}
