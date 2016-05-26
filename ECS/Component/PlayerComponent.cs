using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS.Abilities;

namespace ECS.Component
{
    public class PlayerComponent : Component
    {
        public string Sex { get; set; }
        public int Level { get; set; }

        public int CurrentExperience { get; set; }
        public int MaxExperience { get; set; }


        public List<Item> Inventory { get; set; }
        public Item EquipmentHead { get; set; }
        public Item EquipmentChest { get; set; }
        public Item EquipmentLegs { get; set; }
        public Item EquipmentHands { get; set; }
        public Item EquipmentFeet { get; set; }


        public float CriticalHitChance { get; set; }

        public PlayerComponent()
        {
            ComponentId = "PlayerComponent";
        }
        
    }
}
