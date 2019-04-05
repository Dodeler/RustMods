using System;

namespace Oxide.Plugins
{
    [Info("SyringeNerf", "D", "0.1")] //, "0.1.4", ResourceId = 1809
    // [Description("Syringe healing customization plugin")]
    class SyringeNerf : RustPlugin
    {
        float healAmount = 15f; // Instant heal amount
        float hotAmount = 20f; // Heal-over-time amount

        float hotTime = 10f; // Heal-over-time time
        // bool usePermissions = false; // use permissions
        // private const string perm = "syringedenerf.use";

        object OnHealingItemUse(HeldEntity item, BasePlayer target)
        {
            if (item is MedicalTool && item.ShortPrefabName.Contains("syringe"))
            {
                // if(!hasPermission(target))
                //if(target.SignificantBleeding())
                if (target.metabolism.bleeding.value > 0)
                {
                    Puts(target.displayName + " is bleeding!");
                    target.health = target.health + healAmount;
                    target.metabolism.bleeding.Add(target.metabolism.bleeding.value);

                    // target.metabolism.bleeding.value
                    // target.metabolism.ApplyChange(MetabolismAttribute.Type.Bl)
                }
                else
                {
                    Puts(target.displayName + " is not bleeding!");
                    target.health = target.health + healAmount;
                    target.metabolism.ApplyChange(MetabolismAttribute.Type.HealthOverTime, hotAmount, hotTime);
                }
                // 	return null;

                return true;
            }

            return null;
        }

        
    }
}