using System;
using System.Collections.Generic;
using UnityEngine;

namespace Animation
{
    [CreateAssetMenu(fileName = "SpriteAnimationsConfig", menuName = "Configs/SpriteAnimationsConfig", order = 1)]
    public class SpriteAnimationsConfig : ScriptableObject
    {
        public List<SpritesSequence> Sequences = new List<SpritesSequence>();
        
        [Serializable]
        public class SpritesSequence
        {
            public Track Track;
            public List<Sprite> Sprites = new List<Sprite>();
        }
    }

}