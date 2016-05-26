using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Abilities
{
    public class Skill
    {
        public SkillName SkillName { get; set; }
        public int CurrentLevel { get; set; }
        public int Modifier { get; set; }
    }

    public enum SkillName
    {
        // STR
        Melee,
        HeavyArmor,
        LightArmor,
        //WIS
        Magic,
        //DEX
        Ranged,
        Agility,
        Sneak
    }
}
