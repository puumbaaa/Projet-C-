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
        bool _isDoor;
        bool _isFight;

        public bool IsWalkable { get => _isWalkable; set => _isWalkable = value; }
        public bool IsBorder { get => _isBorder; set => _isBorder = value; }
        public bool IsGrass { get => _isGrass; set => _isGrass = value; }
        public bool IsDoor { get => _isDoor; set => _isDoor = value; }
        public bool IsFight { get => _isFight; set => _isFight = value; }

        public CaseState(string name, bool walkable, bool border, bool grass, bool door) : base(name)
        {
            IsWalkable = walkable;
            IsBorder = border;
            IsGrass = grass;
            IsDoor = door;
        }

        public void StartFight()
        {
            if (IsGrass)
            {
                Random rnd = new Random();
                if (rnd.Next(100) <= 20)
                {
                    IsFight = true;
                }
            }
            IsFight = false;
        }
    }
}
