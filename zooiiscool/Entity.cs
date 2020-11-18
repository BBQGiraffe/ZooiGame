using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using SFML;

namespace zooiiscool
{
    class Entity
    {
        public Vector2 position = new Vector2();
        public Vector2 size = new Vector2();
        public Vector2 center = new Vector2();

        public bool active = true;
        public string texture;

        public float rotation;

        public virtual void Update()
        {
            
        }

        public static Entity Instantiate(Entity entity, Vector2 position = new Vector2(), float rotation = 0)
        {
            entity.position = position;
            entity.rotation = rotation;
            entity.Start();
            Game.Entities.Add(entity);
            return entity;
        }

        

        public virtual void OnCollision(Entity sender)
        {

        }

        public virtual void Start()
        {

        }

        //don't override this you fucking tard
        public void Render()
        {

        }
    }
}
