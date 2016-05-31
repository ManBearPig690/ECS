using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS.Entities;
using CocosSharp;
using ECS.Component;

namespace ECS.Systems
{
    /// <summary>
    /// draws sprites
    /// </summary>
    public class RenderSystem : System
    {
        public override void Update(float dt, ref List<string> componentEntityList)
        {
            //// uses sprite and position component
            //// will update
            foreach (var entityId in componentEntityList)
            {
                EntityManager.Entities[entityId].GetComponent<SpriteComponent>().Sprite.PositionY =
                    EntityManager.Entities[entityId].GetComponent<PositionComponent>().PositionY;

                EntityManager.Entities[entityId].GetComponent<SpriteComponent>().Sprite.PositionX =
                    EntityManager.Entities[entityId].GetComponent<PositionComponent>().PositionX;
            }
        }
    }
}
