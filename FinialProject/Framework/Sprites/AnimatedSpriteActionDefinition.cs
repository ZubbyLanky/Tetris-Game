﻿using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace FinialProject.Framework.Sprites
{
    public sealed class AnimatedSpriteActionDefinition
    {
        public AnimatedSpriteActionDefinition()
        {
            Frames = new List<AnimatedSpriteActionFrameDefinition>();
        }

        public string Name { get; set; }

        public List<AnimatedSpriteActionFrameDefinition> Frames { get; set; }

        [XmlIgnore]
        public int MaxFrameWidth => Frames?.Max(x => x.Width) ?? 0;

        [XmlIgnore]
        public int MaxFrameHeight => Frames?.Max(x => x.Height) ?? 0;
    }
}
