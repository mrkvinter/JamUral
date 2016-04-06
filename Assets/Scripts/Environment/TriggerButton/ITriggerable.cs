using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public interface ITriggerable
    {
        void OnTrigEnter(Collision2D other);
        void OnTrigrExit(Collision2D other);
    }
}
