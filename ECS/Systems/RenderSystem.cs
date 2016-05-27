using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS.Entities;

namespace ECS.Systems
{
    public class RenderSystem : System
    {
        public new void Update(float dt, ref Dictionary<string, Entity> entities, ref List<string> componentEntityList, ref GameLayer gameLayer)
        {
            // get sprites that need rendering
            // use gameLayer ref to render to teh screen
        }
    }
}
