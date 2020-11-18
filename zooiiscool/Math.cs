using System;
using System.Collections.Generic;
using System.Text;

namespace zooiiscool
{
    class Math
    {
        public static bool AABB(Entity a, Entity b)
        {
            //what?
            return (a.position.X < b.position.X + b.size.X && a.position.X + a.size.X > b.position.X && a.position.Y < b.position.Y + b.size.Y && a.position.Y + a.size.Y > b.position.Y);
        }
    }
}
