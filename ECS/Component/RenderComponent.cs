using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Component
{
    /// <summary>
    /// stores data about rending the component
    /// such as bool Display => to make if it needs to display  
    /// RenderSystem will talk to spritesystem to get the images and such it needs to render
    /// also talk to position system to draw at specific position
    /// </summary>
    public class RenderComponent : Component
    {
    }
}
