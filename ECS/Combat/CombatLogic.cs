using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Entities;

namespace Logic.Combat
{
    class CombatLogic
    {
        /// <summary>
        /// calculates melee damage
        /// </summary>
        /// <param name="attacker"></param>
        /// <returns>
        /// int determining the amount of damage => this is applied to targets armor / resistances then remaing amount will damage hp
        /// -1 is returned if it is a miss
        /// </returns>
        public int CalculateMeleeDamage(Entity attacker)
        {
            // str modifier + weapon damage + skill modifier => maybe add *.25 to keep it down
                // not sure if should also add ability damage to this formula when using an ability
                // or to just replace weapon damage with the ability
                // weapon damange will be random number in the weapon damange range i.e. 1-5 damage woudl be random between 1 and 5
            // base damage is str + skill modifer
            // can also add magic damage if the skill or ability being used add magic damage
            return 0;
        }

        /// <summary>
        /// calculates magic damage
        /// </summary>
        /// <param name="attacker"></param>
        /// <returns>
        /// int determining the amount of damage => this is applied to targets magic resistance / resistances then remaing amount will damage hp
        /// -1 is returned if it is a miss
        /// </returns>
        public int CalculateMagicDamage(Entity attacker)
        {
            // wis modifer + weapon / spell damage + skill modifier => maybe add *.25 to keep it down
            // base damage is wis + skill modifer
            // can add extra damage based on ability being used if any
            return 0;
        }

        public void Attack(Entity attacker, Entity target)
        {
            //int damageDone;
            //if (attacker.Attack.DamageType == DamageType.Melee)
            //{
            //    damageDone = CalculateMeleeDamage(attacker);
            //    target.CurrentHitPoints -= damageDone;
            //}
            //else
            //{
            //    damageDone = CalculateMagicDamage(attacker);
            //    target.CurrentHitPoints -= damageDone;
            //}
            

        }

        public void ApplyDamage(int damage, DamageType damageType, Entity target)
        {
            // some sort of logic to determine how much based on armor, or magic resistance
            // DOTs may use this to apply their damage.
        }

        
    }
}
