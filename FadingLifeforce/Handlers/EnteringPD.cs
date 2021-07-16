using Exiled.Events.EventArgs;

namespace FadingLifeforce.Handlers
{
    internal class EnteringPD
    {
        public void OnEnteringPD(EnteringPocketDimensionEventArgs ev)
        {
            ev.Player.AddEffects(FadingLifeforce.Instance.Config.EffectOnPdEnter);
        }
    }
}