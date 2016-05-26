using System.Collections.Generic;
using ECS.Abilities;
using ECS.Entities;

namespace ECS.Component
{
    public class CharacterComponent : Component
    {
        public string Name { get; set; }

        public int Strength { get; set; }
        public int Wisdom { get; set; }
        public int Dexterity { get; set; }
        public int CurrentHitPoints { get; set; }
        public int MaxHitPoints { get; set; }
        public int Mana { get; set; }
        public List<Skill> Skills { get; set; }
        public List<Ability> Abilities { get; set; }

        public Attack Attack { get; set; }
        
        public List<Buff> Buffs { get; set; }
        public List<Buff> DeBuffs { get; set; }

        public CharacterComponent()
        {
            ComponentId = "CharacterComponent";
        }

    }
}
