using System;
using System.Collections.Generic;
using ECS.Component;


namespace ECS.Entities
{
    public class Entity
    {
        // Can have system store a static id for the PlayerEntity and the WorldEntity so it can
        // Go directly to the item in the dictionary on certial operations to mayber look up faster
        public bool DestroyEntity = false;
        public string EntityId; // must be unique
        private Dictionary<Type, Component.Component> Components { get; set; } 

        public Entity()
        {
            EntityId = Guid.NewGuid().ToString();
            Components = new Dictionary<Type, Component.Component>();
        }

        public Entity(Dictionary<Type, Component.Component> components)
        {
            EntityId = Guid.NewGuid().ToString();
            Components = components;
        }

        public Entity(List<Component.Component> components)
        {
            EntityId = Guid.NewGuid().ToString();
        }

        public void AddComponent(Component.Component component)
        {
            Components.Add(component.GetType(), component);
        }

        public T GetComponent<T>() where T : Component.Component
        {
            Component.Component result;
            this.Components.TryGetValue(typeof(T), out result);
            return result as T;
        }
    }
}
