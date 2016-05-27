using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CocosSharp;
using ECS.Component;

namespace ECS
{
    public class GameLayer : CCLayerColor
    {
        private static EntityManager _entityManager;
        private static SystemManager _systemManager;
        private static List<string> _entityDestructionList;
        private static int _score;

        public GameLayer(int width, int height): base(CCColor4B.Black)
        {
            _score = 0;
            _entityManager = new EntityManager();
            _systemManager = new SystemManager();
            _entityDestructionList = new List<string>();

            _entityManager.CreateWorld(width, height);

            _entityManager.CreateBallEntity(0, 0, 0, 0, 140);
            _entityManager.CreatePlayerEntity();
            _entityManager.CreateScoreEntity();
            _systemManager.CreateComponentLists(ref _entityManager.Entities);

            AddChild(_entityManager.Entities["Score"].GetComponent<LabelComponent>().Label);
            AddSprite();
            Schedule(Run);
        }


        private static void Run(float framTimeInSeconds)
        {
            _systemManager.MotionSystem.Update(framTimeInSeconds, ref _entityManager.Entities, ref _systemManager.MotionComponentEntities);
            // run all the rest


            _score += _systemManager.CollisionSystem.Update(framTimeInSeconds, ref _entityManager.Entities, ref _systemManager.CollisionComponentEntities);

            // add input system as touch even handler so it gets called on touch even
            // ??? inputsystem will look for InputComponent and perform action ???

            // Applies the updated positions to sprites
            _systemManager.RenderSystem.Update(framTimeInSeconds, ref _entityManager.Entities,
                ref _systemManager.RenderComponentEntites);

            _entityManager.Entities["Score"].GetComponent<LabelComponent>().Label.Text = "Score: " + _score;
        

            // if entity should be removed
            // remove from entiy list
            // remove from component list used by systems.
            //_entityDestructionList = _entityManager.EntitesToDestroy(); // returns a list
            _entityManager.EntitesToDestroy(ref _entityDestructionList);
            if(_entityDestructionList.Count > 0)
            { 
                _entityManager.DestroyEntity(ref _entityDestructionList);
                _systemManager.RemoveEntity(ref _entityDestructionList);
                _entityDestructionList.Clear();
            }

        }

        private void AddSprite()
        {
            foreach (var entityId in _systemManager.RenderComponentEntites)
            {
                AddChild(_entityManager.Entities[entityId].GetComponent<SpriteComponent>().Sprite);
            }
        }
        
    }
}
