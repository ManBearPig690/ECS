using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Entities
{
    public class Attack
    {
        public DamageType DamageType { get; set; }
    }

    public enum DamageType
    {
        Magic,
        Melee
        // fire, poison etc
    }
}
