using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WorldFlags.Items
{
    public abstract class FlagItem : ModItem
    {
        public bool isBritishFlag = false;
        public bool isAmericanFlag = false;
        public bool isHistorical = false;
        public abstract int FlagItemID();
        public abstract string CountryName();
        public abstract int TileStyleID();
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault($"Flag of {CountryName()}");
            if (isHistorical)
                WorldFlags.HistoricalID.Add(FlagItemID(), TileStyleID());
            else
                WorldFlags.CountryID.Add(FlagItemID(), TileStyleID());
        }
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Swing;
            Item.maxStack = 99;
            Item.width = 24;
            Item.height = 32;
            Item.value = WorldFlags.FlagValue;
            Item.consumable = true;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.rare = ItemRarityID.White;
            if (isHistorical)
                Item.createTile = ModContent.TileType<Tiles.HistoricalTile>();
            else
                Item.createTile = ModContent.TileType<Tiles.FlagTile>();
            Item.placeStyle = TileStyleID() * 2;
        }
        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(FlagItemID());

            if (isBritishFlag)
                recipe.AddIngredient(ModContent.ItemType<UKItem>());
            else if (isAmericanFlag)
                recipe.AddIngredient(ModContent.ItemType<USAItem>());
            else
                recipe.AddIngredient(ItemID.Silk, 10);

            if (isHistorical)
                recipe.AddRecipeGroup(nameof(ItemID.Diamond), 1);

            recipe.AddTile(ModContent.TileType<Tiles.Globe>());
            recipe.Register();
        }
    }
}