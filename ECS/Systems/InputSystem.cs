﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CocosSharp;
using ECS.Entities;

namespace ECS.Systems
{
    public class InputSystem : System
    {
        public void Update(float dt, ref Dictionary<string, Entity> entities, ref List<string> componentEntityList)
        {
            foreach(var entityId in componentEntityList)
            {
                
            }
        }

        void HandleTouchesMoved(List<CCTouch> touches, CCEvent touchevent)
        {
            var locationOnScreen = touches[0].Location;
            //paddleSprite.PositionX = locationOnScreen.X;
        }

    }
}