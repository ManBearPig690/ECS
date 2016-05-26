using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Component
{
    public class PositionComponent : Component
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }

        public PositionComponent(int x, int y)
        {
            PositionX = x;
            PositionY = y;
        }
    }
}
