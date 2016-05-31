using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS.Component;
using ECS.Entities;
using ECS.Systems;
using System = ECS.Systems.System;

namespace ECS
{
    public class SystemManager
    {
        public List<string> PlayerComponentEntities;
        public List<string> MotionComponentEntities;
        public List<string> PositionComponentEntities;
        public List<string> SpriteComponentEntites;
        public List<string> RenderComponentEntites;
        public List<string> InputComponentEntities;
        public List<string> CollisionComponentEntities;
        public InputSystem InputSystem;
        public MotionSystem MotionSystem;
        public CollisionSystem CollisionSystem;
        public RenderSystem RenderSystem;
        

        public SystemManager()
        {
            PlayerComponentEntities = new List<string>();
            MotionComponentEntities = new List<string>();
            PositionComponentEntities = new List<string>();
            SpriteComponentEntites = new List<string>();
            RenderComponentEntites = new List<string>();
            InputComponentEntities = new List<string>();
            CollisionComponentEntities = new List<string>();
            MotionSystem = new MotionSystem();
            CollisionSystem = new CollisionSystem();
            InputSystem = new InputSystem();
            RenderSystem = new RenderSystem();
        }

        public void CreateComponentLists(ref Dictionary<string, Entity> entities)
        {
            foreach (var entity in entities.Values)
            {
                
                var playerComp = entity.GetComponent<PlayerComponent>();
                var motionComp = entity.GetComponent<MotionComponent>();
                var positionComp = entity.GetComponent<PositionComponent>();
                var spriteComp = entity.GetComponent<SpriteComponent>();
                var inputComp = entity.GetComponent<InputComponent>();
                var collisionComp = entity.GetComponent<CollisionComponent>();

                if (playerComp != null)
                    PlayerComponentEntities.Add(entity.EntityId);
                if (motionComp != null)
                    MotionComponentEntities.Add(entity.EntityId);
                if(positionComp != null)
                    PositionComponentEntities.Add(entity.EntityId);
                if (spriteComp != null)
                    SpriteComponentEntites.Add(entity.EntityId);
                if (spriteComp != null && positionComp != null) // adds all entities that have sprite and position so they can be drawn
                    RenderComponentEntites.Add(entity.EntityId);
                if (inputComp != null)
                    InputComponentEntities.Add(entity.EntityId);
                if (collisionComp != null)
                    CollisionComponentEntities.Add(entity.EntityId);

            }
        }

        /// <summary>
        /// removes the entity id from each of hte system's id list
        /// </summary>
        /// <param name="entitIds"></param>
        public void RemoveEntity(ref List<string> entitIds)
        {
            foreach (var id in entitIds)
            {
                var itemToRemove = PlayerComponentEntities.SingleOrDefault(c => c == id);
                if (itemToRemove != null)
                    PlayerComponentEntities.Remove(itemToRemove);

                itemToRemove = MotionComponentEntities.SingleOrDefault(c => c == id);
                if (itemToRemove != null)
                    MotionComponentEntities.Remove(itemToRemove);

                itemToRemove = PositionComponentEntities.SingleOrDefault(c => c == id);
                if (itemToRemove != null)
                    PositionComponentEntities.Remove(itemToRemove);

                itemToRemove = SpriteComponentEntites.SingleOrDefault(c => c == id);
                if (itemToRemove != null)
                    SpriteComponentEntites.Remove(itemToRemove);

                itemToRemove = RenderComponentEntites.SingleOrDefault(c => c == id);
                if (itemToRemove != null)
                    RenderComponentEntites.Remove(itemToRemove);

                itemToRemove = InputComponentEntities.SingleOrDefault(c => c == id);
                if (itemToRemove != null)
                    InputComponentEntities.Remove(itemToRemove);
            }
            
        }

    }
}
