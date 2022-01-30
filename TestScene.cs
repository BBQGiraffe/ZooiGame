using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
namespace zooiiscool
{
    class TestScene : Scene
    {



        Text kills = new Text();

        Random rnd = new Random(2349);
        public override void Start()
        {
            Entity.Instantiate(new zooientity());

            for(int i = 0; i < 5; i++)
            {
                Entity.Instantiate(new EvilZooi(), new System.Numerics.Vector2(rnd.Next(640, 1280), rnd.Next(32, 680)));
                GameManager.EnemyCount++;
            }

            kills.Font = new Font("IstokWeb-Bold.ttf");
            kills.Color = new Color(255, 255, 255);
        }


        public float RespawnTimer = 0f;
        public float RespawnTime = 1.5f;
        public override void Update()
        {
            if(GameManager.EnemyCount < GameManager.MaxEnemies)
            {
                GameManager.kills++;

                EvilZooi zooi = (EvilZooi)Entity.Instantiate(new EvilZooi(), new System.Numerics.Vector2(rnd.Next(640, 1280), rnd.Next(32, 680)));
                
                if(GameManager.kills % 10 == 0)
                {
                    zooi.texture = "miniboss.png";
                    zooi.movespeed += 30;
                    zooi.health *= 5;
                    zooi.FireTime = .19f;
                    Audio.PlaySound("bossspawn.wav", false);
                }
                GameManager.EnemyCount++;
            }

            if (!GameManager.alive)
            {
                RespawnTimer += Time.DeltaTime;
                if(RespawnTimer >= RespawnTime)
                {
                    Audio.PlaySound("Respawn.wav", false);
                    RespawnTimer = 0f;
                    Entity.Instantiate(new zooientity());
                    GameManager.alive = true;
                }
            }
            kills.DisplayedString = "Kills: " + GameManager.kills;

        }

        public override void Render()
        {
            Game.window.Draw(kills);
        }
    }
}
