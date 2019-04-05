using System;

namespace Oxide.Plugins
{
    [Info("BandageNerf", "D", "0.1")] //, "0.1.4", ResourceId = 1809
    // [Description("Bandage healing customization plugin")]
    class BandageNerf : RustPlugin
    {

        object OnHealingItemUse(HeldEntity item, BasePlayer target)
        {
            if (item is MedicalTool && item.ShortPrefabName.Contains("bandage"))
            {
                if (target.metabolism.bleeding.value > 0)
                {
                    Puts(target.displayName + " is bleeding!");
                    if (target.metabolism.bleeding.value > 20)
                    {
                        target.metabolism.bleeding.value -= 20;
                    }
                    else
                    {
                        target.metabolism.bleeding.value = 0;
                    }
                    return true;
                }
                else
                {
                    Puts(target.displayName + " is not bleeding!");
                    return false; // no healing unless bleeding - maybe allow healing if very cold?
                }
            }

            return null;
        }

        
    }
}