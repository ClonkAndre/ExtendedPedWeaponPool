using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

using IVSDKDotNet;
using IVSDKDotNet.Enums;

using static IVSDKDotNet.Native.Natives;

namespace ExtendedPedWeaponPool {
    public class Main : Script {

        public Main()
        {
            Initialized += Main_Initialized;
            Tick += Main_Tick;
        }

        private void Main_Initialized(object sender, EventArgs e)
        {
            
        }

        private void Main_Tick(object sender, EventArgs e)
        {
            int playerID = CONVERT_INT_TO_PLAYERINDEX(GET_PLAYER_ID());
            GET_PLAYER_CHAR(playerID, out int pPed);

            int[] peds = CPools.GetAllPedHandles();
            for (int i = 0; i < peds.Length; i++)
            {
                int ped = peds[i];
                
                if (ped == pPed)
                    continue;
                if (IS_CHAR_DEAD(ped))
                    continue;

                // Peds können nicht angreifen wenn sie einen Kö in der Hand haben!

                GIVE_WEAPON_TO_CHAR(ped, (uint)eWeaponType.WEAPON_POOLCUE, 1, false);
            }
        }

    }
}
