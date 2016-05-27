using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CocosSharp;

namespace ECS.Component
{
    class LabelComponent : Component
    {
        public CCLabel Label { get; set; }

        public LabelComponent(string text, string font, int size)
        {
            Label = new CCLabel(text, font, size, CCLabelFormat.SystemFont);
        }
    }
}
