using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CocosSharp;

namespace ECS
{
    public class GameLayer : CCLayerColor
    {
        private static EntityManager _entityManager;
        private static SystemManager _systemManager;
        private static List<string> _entityDestructionList;

        public GameLayer(): base(CCColor4B.Black)
        {
            _entityManager = new EntityManager();
            _systemManager = new SystemManager();
            _entityDestructionList = new List<string>();

            _entityManager.CreateWorld();
            _entityManager.CreateBallEntity(0, 0, 0, 0, 140);
            _entityManager.CreatePlayerEntity();

            _systemManager.CreateComponentLists(ref _entityManager.Entities);


            Schedule(Run);
        }


        private void Run(float framTimeInSeconds)
        {
            _systemManager.MotionSystem.Update(framTimeInSeconds, ref _entityManager.Entities, ref _systemManager.MotionComponentEntities);
            // run all the rest


            // if entity should be removed
            // remove from entiy list
            // remove from component list used by systems.
            _entityDestructionList = _entityManager.EntitesToDestroy();
            _entityManager.DestroyEntity(ref _entityDestructionList);
            _systemManager.RemoveEntity(ref _entityDestructionList);
            _entityDestructionList.Clear();
        }
    }
}
