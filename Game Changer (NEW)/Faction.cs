using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Changer__NEW_
{
    class Faction
    {
        public int goldCount;
        public int goldPerSecond;
        public int luxuryCount;
        public string factionName;
        public int CPhp;
        public Faction(string factionName)
        {
            goldCount = 100;
            goldPerSecond = 0;
            luxuryCount = 0;
            CPhp = 20;
        }
    }
}
