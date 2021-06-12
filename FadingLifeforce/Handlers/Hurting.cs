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
                FadingLifeforce.AddEffects(Configs.EffectOnFall, ev.Target);
                return;
            }

            if (ev.DamageType.isWeapon)
            {
                FadingLifeforce.AddEffects(Configs.EffectOnShot, ev.Target);
                return;
            }

            if (ev.DamageType.isScp)
            {
                FadingLifeforce.AddEffects(Configs.EffectOnHurtByScp, ev.Target);
                return;
            }
        }
    }
}