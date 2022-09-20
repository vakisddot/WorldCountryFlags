using System.Collections.Generic;
using System.IO;
using Terraria.ModLoader;

namespace WorldFlags
{
	public class WorldFlags : Mod
	{
		public const int FlagValue = 5000;

        // Country Item ID - Key
        // Country Tile ID - Value
        public static Dictionary<int, int> CountryID = new Dictionary<int, int>();

        public static Dictionary<int, int> HistoricalID = new Dictionary<int, int>();
    }
}