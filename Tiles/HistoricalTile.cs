using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria;

namespace WorldFlags.Tiles
{
    internal class HistoricalTile : FlagTile
    {
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int id = frameX / 108;
            int item = 0;

            foreach (int countryByName in WorldFlags.HistoricalID.Keys)
            {
                if (WorldFlags.HistoricalID[countryByName] == id)
                {
                    item = countryByName;
                }
            }

            if (item > 0)
            {
                Item.NewItem(new EntitySource_TileBreak(i, j), new Vector2(i * 16, j * 16), new Vector2(48, 48), item);
            }
        }
    }
}
