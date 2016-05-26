using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ECS;

namespace EcsUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Engine engine = new Engine();
            bool falling = true;
            while (falling)
            {
                engine.ExecuteSystems();
                Console.Write(engine);
            }
        }
    }
}
