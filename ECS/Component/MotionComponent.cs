using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Component
{
    public class MotionComponent : Component
    {
        public float VelocityX { get; set; }
        public float VelocityY { get; set; }
        public float Rotation { get; set; }
        public float Gravity { get; set; }
    }
}
