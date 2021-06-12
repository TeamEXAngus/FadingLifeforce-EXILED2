using Exiled.Events.EventArgs;

namespace FadingLifeforce.Handlers
{
    internal class EnteringPD
    {
        public void OnEnteringPD(EnteringPocketDimensionEventArgs ev)
        {
            FadingLifeforce.AddEffects(FadingLifeforce.Instance.Config.EffectOnPdEnter, ev.Player);
        }
    }
}