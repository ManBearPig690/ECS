using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Component
{
    public class MotionComponent : Component
    {
        public int VelocityX { get; set; }
        public int VelocityY { get; set; }
        public float Rotation { get; set; }
    }
}
