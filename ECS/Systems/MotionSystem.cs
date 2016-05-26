﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS.Component;
using ECS.Entities;

namespace ECS.Systems
{
    public class MotionSystem : System
    {


        // might need to set frame rate/ update in secons some where get how many animation frames
        public override void Update(float dt, ref Dictionary<string, Entity> entities, ref List<string> componentEntityList)
        {
            foreach (var entityId in componentEntityList)
            {
                entities[entityId].GetComponent<PositionComponent>().PositionX += entities[entityId].GetComponent<MotionComponent>().VelocityX * dt; 
                entities[entityId].GetComponent<PositionComponent>().PositionY += entities[entityId].GetComponent<MotionComponent>().VelocityY * dt;
            }
        }


    }
}
