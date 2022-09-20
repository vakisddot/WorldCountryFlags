using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ObjectData;
using Terraria.Enums;
using System;

namespace WorldFlags.Tiles
{
    public class FlagTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileSolid[Type] = false;
            Main.tileLavaDeath[Type] = true;
            Main.tileNoAttach[Type] = true;

            TileID.Sets.DisableSmartCursor[Type] = true;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x4);
            TileObjectData.newTile.StyleHorizontal = true;

            TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
            TileObjectData.newTile.Origin = new Point16(1, 3);
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidWithTop | AnchorType.SolidTile, 1, 2);

            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);

            TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
            TileObjectData.newAlternate.AnchorBottom = new AnchorData(AnchorType.SolidWithTop | AnchorType.SolidTile, 1, 0);

            TileObjectData.addAlternate(1);
            TileObjectData.addTile(Type);

            DustType = DustID.Iron;

            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Country Flag");

            AddMapEntry(new Color(200, 200, 200), name);
            AnimationFrameHeight = 72;
        }
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int id = frameX / 108;
            int item = 0;

            foreach (int countryByName in WorldFlags.CountryID.Keys)
            {
                if (WorldFlags.CountryID[countryByName] == id)
                {
                    item = countryByName;
                }
            }

            if (item > 0)
                Item.NewItem(new EntitySource_TileBreak(i, j), new Vector2(i * 16, j * 16), new Vector2(48, 48), item);
        }

        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            int animationSpeed;
            float windSpeed = Math.Abs(Main.windSpeedCurrent);

            if (windSpeed >= 0 && windSpeed < 0.2)
                animationSpeed = 8;
            else if (windSpeed >= 0.2 && windSpeed < 0.4)
                animationSpeed = 7;
            else if (windSpeed >= 0.4 && windSpeed < 0.6)
                animationSpeed = 6;
            else
                animationSpeed = 5;

            if (++frameCounter > animationSpeed)
            {
                frameCounter = 0;
                if (++frame > 5)
                    frame = 0;
            }
        }
    }
}