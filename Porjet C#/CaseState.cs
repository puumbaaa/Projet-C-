using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Porjet_C_
{
    internal class CaseState : Component
    {
        bool _isWalkable;
        bool _isBorder;
        bool _isGrass;

        public bool IsWalkable { get => _isWalkable; set => _isWalkable = value; }
        public bool IsBorder { get => _isBorder; set => _isBorder = value; }
        public bool IsGrass { get => _isGrass; set => _isGrass = value; }

        public CaseState(string name, bool walkable, bool border, bool grass) : base(name) 
        {
            IsWalkable = walkable;
            IsBorder = border;
            IsGrass = grass;
        }

        public bool StartFight()
        {
            if (IsGrass)
            {
                Random rnd = new Random();
                if (rnd.Next(100) <= 20)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
