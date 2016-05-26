using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Abilities;

namespace Logic.Items
{
    class Armor : Item
    {
    	public ArmorType ArmorType { get; set; }
        public ArmorClass ArmorClass { get; set; }
        public EquipmentSlot EquipmentSlot { get; set; }
    	public int PhysicalDefense { get; set; }
    	public int MagicDefense { get; set; }
        public int SocketCount { get; set; }
        public Dictionary<SkillName, int> SkillModifier { get; set; } 
    }

    public enum ArmorType
    {
        Cloth,
        Leather,
        Mail,
        Plate
    }

    public enum ArmorClass
    {
        Light, // cloth leather
        Heavy // mail plate
    }

    public enum EquipmentSlot
    {
        Head,
        Chest,
        Hands,
        Legs,
        Feet
    }
}
