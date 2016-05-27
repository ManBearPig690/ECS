using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS.Component;
using ECS.Entities;

namespace ECS
{
    /// <summary>
    /// creates and manages entities, could pass params so that they could in turn
    /// be passed to the corrisponding components depending on the entity
    /// </summary>
    public class EntityManager
    {

        public Dictionary<string, Entity> Entities;
        public string BallEntity;

        public EntityManager()
        {
            Entities = new Dictionary<string, Entity>();
        }

        public void CreateWorld(int width, int height)
        {
            var worldEntity = new Entity();
            worldEntity.AddComponent(new PositionComponent(0, 0));
            worldEntity.AddComponent(new SpriteComponent());

            Entities.Add(worldEntity.EntityId, worldEntity);
        }

        public void CreateBallEntity(float pY, float pX, float vX, float vY, float gravity)
        {
            var ballEntity = new Entity();
            ballEntity.AddComponent(new PositionComponent(pX, pY));
            ballEntity.AddComponent(new SpriteComponent());
            ballEntity.AddComponent(new MotionComponent(vX, vY, -140));

            Entities.Add(ballEntity.EntityId, ballEntity);
            BallEntity = ballEntity.EntityId;
        }

        public void CreatePlayerEntity()
        {
            var playerEntity = new Entities.Entity();
            //playerEntity.AddComponent(new PlayerComponent());
            //playerEntity.AddComponent(new CharacterComponent());
            playerEntity.AddComponent(new InputComponent());
            playerEntity.AddComponent(new PositionComponent(0, 0));
            playerEntity.AddComponent(new MotionComponent(0,0,0));
            playerEntity.AddComponent(new SpriteComponent());

            Entities.Add(playerEntity.EntityId, playerEntity);
        }

        public void CreateScoreEntity()
        {
            var scoreEntity = new Entity();
            scoreEntity.AddComponent(new PositionComponent(0, 0));
            scoreEntity.AddComponent(new LabelComponent("Score: 0", "Ariel", 20));
            scoreEntity.EntityId = "Score";
            Entities.Add(scoreEntity.EntityId, scoreEntity);
        }

        public void DestroyEntity(ref List<string> entities)
        {
            foreach (var entityId in entities)
            {
                Entities.Remove(entityId);    
            }
            
        }

        public void EntitesToDestroy(ref List<string> entityDestructionList)
        {
            entityDestructionList = (from entity in Entities.Values where entity.DestroyEntity select entity.EntityId).ToList();
            // return list  logic
            //return (from entity in Entities.Values where entity.DestroyEntity select entity.EntityId).ToList();
        }
    }
}
