using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS.Component;

namespace ECS
{
    public class EntityManager
    {
        public void CreatePlayerEntity()
        {
            var playerEntity = new Entities.Entity();
            playerEntity.AddComponent(new PlayerComponent());
            playerEntity.AddComponent(new CharacterComponent());
            playerEntity.AddComponent(new PositionComponent(0, 0));
            playerEntity.AddComponent(new MotionComponent());
            playerEntity.AddComponent(new SpriteComponent());
            playerEntity.AddComponent(new RenderComponent());
        }
    }
}
