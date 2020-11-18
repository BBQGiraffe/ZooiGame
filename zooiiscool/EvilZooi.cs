using System;
using System.Collections.Generic;
using System.Text;

namespace zooiiscool
{
    enum movedir
    {
        up,
        down
    };
    class EvilZooi : Entity
    {
        movedir dir = movedir.up;
        public float movespeed = 130f;
        float FireTimer = 0f;
        public float FireTime = 1.5f;

        public int health = 500;
        bool boss = false;

        public override void Start()
        {
            texture = "evilzooi.png";
          
        }
        public override void Update()
        {
            FireTimer += Time.DeltaTime;
            if(FireTimer >= FireTime)
            {
                FireTimer = 0f;
                Instantiate(new Bullet(150, -1, SenderType.badguy), center);
            }

            //shit
            switch (dir)
            {
                case movedir.up:
                    position.Y -= movespeed * Time.DeltaTime;
                    break;
                case movedir.down:
                    position.Y += movespeed * Time.DeltaTime;
                    break;
                default:
                    break;


            }

            //determine direction that hsould go nyoom yes
            if(position.Y <= size.Y/2 && dir == movedir.up)//doesn't matter cuz square
            {
                dir = movedir.down;
                return;
            }

            if(position.Y >= 720 - size.Y && dir == movedir.down)
            {
                dir = movedir.up;
            }
            if(health <= 0)
            {
                active = false;
                Audio.PlaySound("EnemyDie.wav", false);
                GameManager.EnemyCount--;
            }
            
        }

        public override void OnCollision(Entity sender)
        {
            if (sender is Bullet)
            {
                var bullet = (Bullet)sender;
                if(bullet.type == SenderType.player)
                {
                    sender.active = false;
                    Audio.PlaySound("HitEnemy.wav", false, 20);
                    health -= 50;
                }
                if (boss)
                {

                }
            }
        }
    }
}
