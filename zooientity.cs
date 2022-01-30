using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using SFML.Audio;//a

namespace zooiiscool
{
    class zooientity : Entity
    {
        float speed = 180;
        Vector2 velocity = new Vector2();
        public override void Start()
        {
            texture = "zooi.png";
        

            position = new System.Numerics.Vector2(100, 100);
        }

        float FireTime = .1f;
        float FireTimer = 0f;

        int health = 100;


        void Shoot()
        {
            if (FireTimer >= FireTime)
            {
                FireTimer = 0;
                Instantiate(new Bullet(800, 1, SenderType.player), center + new Vector2(50, 0));
                Audio.PlaySound("PlayerFire.wav", false);
            }
        }

        public override void Update()
        {

            FireTimer += Time.DeltaTime;
            





            rotation += Time.DeltaTime * 30;
            velocity = Vector2.Zero;

            if (Input.IsKeyDown("up"))
            {
                velocity.Y = -1;
            }
            if (Input.IsKeyDown("down"))
            {
                velocity.Y = 1;
            }
            if (Input.IsKeyDown("left"))
            {
                velocity.X = -1;
            }
            if (Input.IsKeyDown("right"))
            {
                velocity.X = 1;
            }
            if (Input.IsKeyDown("fire"))
            {
                Shoot();
            }
            position += velocity * Time.DeltaTime * speed;
            if(health <= 0)
            {
                active = false;
                Audio.PlaySound("GameOverSFX.wav", false);
                GameManager.alive = false;
                GameManager.kills = 0;
            }

        }

        public override void OnCollision(Entity sender)
        {
            if(sender is Bullet)
            {
                var bullet = (Bullet)sender;
                health -= 5;
                sender.active = false;

            }
        }
    }
}
