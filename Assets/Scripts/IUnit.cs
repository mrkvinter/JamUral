using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public interface IUnit
    {
        int HP { get; }
        int Mana { get; }
        float MoveSpeed { get; }
        bool IsDead { get; }
        IUnit Target { get; }

        void Move();
    }
}
