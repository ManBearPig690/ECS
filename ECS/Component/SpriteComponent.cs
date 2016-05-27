using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CocosSharp;
namespace ECS.Component
{
    /// <summary>
    /// data for creating sprites
    /// </summary>
    public class SpriteComponent : Component
    {
        public CCSprite Sprite { get; set; }
    }
}
