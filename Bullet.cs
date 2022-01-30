using System;
using System.Collections.Generic;
using System.Text;

namespace zooiiscool
{
    enum SenderType
    {

        player,
        badguy
    };

    class Bullet : Entity
    {
        float speed = 420;
        float time = 0f;
        float maxtime = 20;
        float direction = 0f;
        public override void Start()
        {
            texture = "pluto.png";
        }
        
        public SenderType type;

        public Bullet(float speed, float direction, SenderType type)
        {
            this.speed = speed;
            this.type = type;
            this.direction = direction;
        }
        public override void Update()
        {
            time += Time.DeltaTime;
            if(time >= maxtime)
            {
                active = false;
            }

            position.X += direction*speed * Time.DeltaTime;
        }
    }
}
