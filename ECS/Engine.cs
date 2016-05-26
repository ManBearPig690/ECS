using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using CocosSharp;


namespace ECS
{
    public class Engine : CCLayerColor
    {
        private static EntityManager _entityManager = new EntityManager();
        private static SystemManager _systemManager = new SystemManager();
        private static List<string> _entityDestructionList = new List<string>();

        public Engine() : base(CCColor4B.Blue)
        {
            
        }

        public void Init()
        {
            // all operations for starting up the engine, 
            //enity creation can be called here
            _entityManager.CreateWorld();
           // _entityManager.CreateBallEntity();
            _entityManager.CreatePlayerEntity();
        }

        public void Run()
        {
            // contains the looping update of all the systems
           
            while (true)
            {
                ExecuteSystems();
                break;
            }
            
        }

        public void ExecuteSystems()
        {
            _systemManager.MotionSystem.Update(.1f, ref _entityManager.Entities, ref _systemManager.MotionComponentEntities);
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
