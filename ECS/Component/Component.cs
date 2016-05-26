using System;

namespace ECS.Component
{
    public class Component
    {
        public string ComponentId; 

        public Component()
        {
            ComponentId = Guid.NewGuid().ToString();
        }
    }
}
