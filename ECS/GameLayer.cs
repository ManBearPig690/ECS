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
        //private static EntityManager _entityManager;
        private static SystemManager _systemManager;
        private static List<string> _entityDestructionList;
        private static int _score;

        public GameLayer(int width, int height): base(CCColor4B.Black)
        {
            _score = 0;
            //_entityManager = new EntityManager();
            _systemManager = new SystemManager();
            _entityDestructionList = new List<string>();

            EntityManager.CreateWorld(width, height, "map");

            EntityManager.CreateBallEntity(320, 600, 0, 0, 140, "ball");
            EntityManager.CreatePlayerEntity(100, 100, 0, 0, "paddle");
            EntityManager.CreateScoreEntity();
            _systemManager.CreateComponentLists(ref EntityManager.Entities);

            AddChild(EntityManager.Entities["Score"].GetComponent<LabelComponent>().Label);
            EntityManager.Entities["Score"].GetComponent<LabelComponent>().Label.AnchorPoint = CCPoint.AnchorUpperLeft;

            AddSprite();
            Schedule(Run);
        }

        protected override void AddedToScene()
        {
            base.AddedToScene();
            // Use the bounds to layout the positioning of our drawable assets
            CCRect bounds = VisibleBoundsWorldspace; // is this used?
            // Register for touch events
            var touchListener = new CCEventListenerTouchAllAtOnce();
            //touchListener.OnTouchesEnded = OnTouchesEnded; // system manager -> InputSystem.Update() -> will handle object(s) with InputComponent
            touchListener.OnTouchesMoved = _systemManager.InputSystem.HandleTouchesMoved;
            AddEventListener(touchListener, this); // fine
        }

        private void Run(float framTimeInSeconds)
        {
            _systemManager.MotionSystem.Update(framTimeInSeconds, ref _systemManager.MotionComponentEntities);
            // run all the rest

            _systemManager.RenderSystem.Update(framTimeInSeconds, ref _systemManager.RenderComponentEntites);
            var scoring = _systemManager.CollisionSystem.Update(framTimeInSeconds, ref _systemManager.CollisionComponentEntities, VisibleBoundsWorldspace.MinX, VisibleBoundsWorldspace.MaxX, VisibleBoundsWorldspace.MinY);
            
            if (scoring == -1)
                _score = 0;

            EntityManager.Entities["Score"].GetComponent<LabelComponent>().Label.Text = "Score: " + _score;
            
        

            // if entity should be removed
            // remove from entiy list
            // remove from component list used by systems.
            //_entityDestructionList = _entityManager.EntitesToDestroy(); // returns a list
            EntityManager.EntitesToDestroy(ref _entityDestructionList);
            if(_entityDestructionList.Count > 0)
            {
                EntityManager.DestroyEntity(ref _entityDestructionList);
                _systemManager.RemoveEntity(ref _entityDestructionList);
                _entityDestructionList.Clear();
            }

        }

        private void AddSprite()
        {
            foreach (var entityId in _systemManager.RenderComponentEntites)
            {
                AddChild(EntityManager.Entities[entityId].GetComponent<SpriteComponent>().Sprite);
            }
        }
        
    }
}
