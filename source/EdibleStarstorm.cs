using System.Linq;
using BepInEx;
using R2API;
using RoR2;
using SS2;

namespace EdibleStarstorm;

[BepInDependency(ItemAPI.PluginGUID)]
[BepInDependency(SS2Main.GUID)]
[BepInPlugin("Xaidee.EdibleStarstorm", "EdibleStarstorm", "0.1.0")]
public class EdibleStarstorm : BaseUnityPlugin
{
    
    public void Awake()
    {
        Log.Init(Logger);
        ItemCatalog.availability.CallWhenAvailable(ChangeTags);
    }

    private static void ChangeTags()
    {
        Log.Debug("Attempting to change Starstorm ItemTags");
        ItemDef[] shouldBeFoodRelated = 
            [
                // White/Common (Quick Fix & Seared Steak)
                SS2Content.Items.CoffeeBag,
                SS2Content.Items.DetritiveTrematode,
                // Green/Uncommon (Hearty Stew)
                SS2Content.Items.LightningOnKill, // (Man-o'-War)
                SS2Content.Items.StrangeCan,
                // Red/Legendary (Ultimate Meal)
                SS2Content.Items.GreenChocolate,
            ];
        foreach (var itemDef in shouldBeFoodRelated)
        {
            if (itemDef.tags.Contains(ItemTag.FoodRelated))
            {
                Log.Warning($"{itemDef.name} is already FoodRelated!");
                continue;
            }
            itemDef.tags = itemDef.tags.Append(ItemTag.FoodRelated).ToArray();
            Log.Debug($"Added FoodRelated ItemTag to {itemDef.name} successfully ({string.Join(", ", itemDef.tags)})");
        }
    }
}