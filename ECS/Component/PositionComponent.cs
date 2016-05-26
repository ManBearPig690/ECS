using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Component
{
    public class PositionComponent : Component
    {
        public float PositionX { get; set; }
        public float PositionY { get; set; }

        public PositionComponent(float x, float y)
        {
            PositionX = x;
            PositionY = y;

            ComponentId = "PositionComponent";
        }
    }
}
