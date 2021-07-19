using Exiled.API.Features;
using Exiled.Events.EventArgs;

namespace FadingLifeforce.Handlers
{
    internal class Hurting
    {
        private Config Configs => FadingLifeforce.Instance.Config;

        public void OnHurting(HurtingEventArgs ev)
        {
            if (ev.DamageType == DamageTypes.Falldown)
            {
                ev.Target.AddEffects(Configs.EffectOnFall);
                return;
            }

            if (ev.Attacker == ev.Target)
                return;

            if (ev.DamageType.isWeapon && ev.Target.EffectOnShotAllowed(ev.Attacker))
            {
                ev.Target.AddEffects(Configs.EffectOnShot);
                return;
            }

            if (ev.DamageType.isScp)
            {
                ev.Target.AddEffects(Configs.EffectOnHurtByScp);
                return;
            }
        }
    }
}