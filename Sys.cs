using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Terraria.Localization;

namespace WorldFlags
{
    internal class Sys : ModSystem
    {
        public override void AddRecipeGroups()
        {
            RecipeGroup group = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} Gem", ItemID.Diamond, ItemID.Amber, ItemID.Ruby, ItemID.Emerald, ItemID.Sapphire, ItemID.Topaz, ItemID.Amethyst);
            RecipeGroup.RegisterGroup(nameof(ItemID.Diamond), group);
        }
    }
}
