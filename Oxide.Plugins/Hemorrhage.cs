using System;

namespace Oxide.Plugins
{
    [Info("Hemorrhage", "D", "0.1")] //, "0.1.4", ResourceId = 1809
    // [Description("Syringe healing customization plugin")]
    class Hemorrhage : RustPlugin
    {
        private int HEM_0 = 0;
        private int HEM_1 = 20;
        private int HEM_2 = 40;
        private int HEM_3 = 60;
        private int HEM_4 = 80;
        private int HEM_MAX = 100;

        private float HEM_0_X = 2.0f;
        private float HEM_1_X = 4f;
        private float HEM_2_X = 8f;
        private float HEM_3_X = 12f;
        private float HEM_4_X = 20f;
        
      
 
        
        object OnEntityTakeDamage(BaseCombatEntity entity, HitInfo info)
        {
            
            //if (info.type == DamageType.Bleeding)
            //Puts(string.Join(",", info.damageTypes.types));
            if (info.damageTypes.Has(Rust.DamageType.Bleeding))
            {
                Puts("OnEntityTakeDamage  -  target is bleeding");
                BasePlayer bp = (BasePlayer) entity;
                
                double bleed_val = (double) bp.metabolism.bleeding.value;
                float multiplier = HemorrhageMultiplier(bleed_val);
                info.damageTypes.Scale(Rust.DamageType.Bleeding, multiplier);
                //info.damageAmount = info.damageAmount * multiplier;
            }
            return null;
        }
        /*void OnPlayerMetabolize(PlayerMetabolism metabolism, BaseCombatEntity entity, float delta)
        {
            Puts("OnPlayerMetabolize works!");

            double original_bleed_value = (double) metabolism.bleeding.value;
            metabolism.bleeding.SetValue(0);
            


        }*/

        float HemorrhageMultiplier(double bleed)
        {
            if (bleed >= HEM_0 && bleed <= HEM_1-1)
            {
                Puts("Hem level 0");
                return HEM_0_X;
            }
            else if (bleed >= HEM_1 && bleed <= HEM_2-1)
            {
                Puts("Hem level 1");
                return HEM_1_X;
            }
            else if (bleed >= HEM_2 && bleed <= HEM_3-1)
            {
                Puts("Hem level 2");
                return HEM_2_X;
            }
            else if (bleed >= HEM_3 && bleed <= HEM_4)
            {
                Puts("Hem level 3");
                return HEM_3_X;
            }
            else if (bleed >= HEM_4 && bleed <= HEM_MAX)
            {
                Puts("Hem level 4");
                return HEM_4_X;
            }
            else
            {
                Puts("unexpected bleed value!");
                return 1.0f;
            }
        }
    }
}