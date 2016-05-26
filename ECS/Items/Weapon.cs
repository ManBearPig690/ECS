using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS.Abilities;

namespace ECS.Items
{
    class Weapon : Item
    {
    	public WeaponType Type { get; set; }
    	public int PhysicalDamage {get;set;}
    	public int MagicDamage {get;set;}
        public int SocketCount { get; set; }
        public Dictionary<SkillName, int> SkillModifier { get; set; } 
    }

    public enum WeaponType
    {
        // sowrd, axe, dagger etc...
    }
}
