using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ECS;
using ECS.Component;

namespace EcsUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GravityTest()
        {
            var eManager = new EntityManager();
            var sManager = new SystemManager();
            eManager.CreateBallEntity(0, 0, 0, 0, 140, "ball");
            sManager.CreateComponentLists(ref eManager.Entities);

            bool falling = true;
            while (falling)
            {
                sManager.MotionSystem.Update(.1f, ref eManager.Entities, ref sManager.MotionComponentEntities);
                float positionY =
                    eManager.Entities[sManager.MotionComponentEntities[0]].GetComponent<PositionComponent>().PositionY;
                float positionX =
                    eManager.Entities[sManager.MotionComponentEntities[0]].GetComponent<PositionComponent>().PositionX;
                Console.WriteLine("{0}, {1}", positionX, positionY);

                if (positionY >= 200)
                    falling = false;
            }
        }
    }
}
