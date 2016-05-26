using System;

namespace Logic.Component
{
    public class Component
    {
        public readonly string ComponentId; 

        public Component()
        {
            ComponentId = Guid.NewGuid().ToString();
        }
    }
}
