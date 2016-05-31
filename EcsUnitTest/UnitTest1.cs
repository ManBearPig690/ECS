using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ECS;
using ECS.Component;

namespace EcsUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestInitialize]
        public void Init()
        {
            EntityManager.CreateBallEntity(0, 0, 0, 0, 140, "ball");
        }

        [TestMethod]
        public void GravityTest()
        {
            //var eManager = new EntityManager();
            var sManager = new SystemManager();
            sManager.CreateComponentLists(ref EntityManager.Entities);

            bool falling = true;
            while (falling)
            {
                sManager.MotionSystem.Update(.1f, ref sManager.MotionComponentEntities);
                float positionY =
                    EntityManager.Entities[sManager.MotionComponentEntities[0]].GetComponent<PositionComponent>().PositionY;
                float positionX =
                    EntityManager.Entities[sManager.MotionComponentEntities[0]].GetComponent<PositionComponent>().PositionX;
                Console.WriteLine("{0}, {1}", positionX, positionY);

                if (positionY >= 200)
                    falling = false;
            }
        }
    }
}
