using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
    [System.Serializable]
    public struct ParallaxObject
    {
        public Transform Background;
        public double ParallaxScale;

        public ParallaxObject(Transform obj, double scale)
        {
            Background = obj;
            ParallaxScale = scale;
        }
    }
}
