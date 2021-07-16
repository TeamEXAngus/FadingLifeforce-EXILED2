using MEC;
using System;
using Exiled.API.Enums;
using Exiled.API.Features;
using System.Collections.Generic;
using PlayerHandler = Exiled.Events.Handlers.Player;

namespace FadingLifeforce
{
    public class FadingLifeforce : Plugin<Config>
    {
        private static readonly FadingLifeforce singleton = new FadingLifeforce();
        public static FadingLifeforce Instance => singleton;

        public override PluginPriority Priority { get; } = PluginPriority.Medium;

        public override Version RequiredExiledVersion { get; } = new Version(2, 10, 0);
        public override Version Version { get; } = new Version(1, 0, 5);

        private Handlers.Hurting hurting;
        private Handlers.EnteringPD enteringPD;

        private FadingLifeforce()
        { }

        public override void OnEnabled()
        {
            RegisterEvents();
        }

        public override void OnDisabled()
        {
            UnregisterEvents();
        }

        public void RegisterEvents()
        {
            hurting = new Handlers.Hurting();
            enteringPD = new Handlers.EnteringPD();

            PlayerHandler.Hurting += hurting.OnHurting;
            PlayerHandler.EnteringPocketDimension += enteringPD.OnEnteringPD;
        }

        public void UnregisterEvents()
        {
            PlayerHandler.Hurting -= hurting.OnHurting;
            PlayerHandler.EnteringPocketDimension -= enteringPD.OnEnteringPD;

            hurting = null;
            enteringPD = null;
        }
    }

    internal static class Extensions
    {
        public static void AddEffects(this Player player, Dictionary<EffectType, float[]> dict)
        {
            foreach (var kvp in dict)
            {
                if (kvp.Value[0] > UnityEngine.Random.Range(1, 101))
                    player.EnableEffect(kvp.Key, kvp.Value[1]);
            }
        }

        public static bool EffectOnShotAllowed(this Player Player, Player Attacker)
        {
            bool SCPCheck = (!Player.IsScp) || FadingLifeforce.Instance.Config.EffectOnShotAffectScps;
            bool WeaponCheck = !FadingLifeforce.Instance.Config.IgnoredGuns.Contains(Attacker.CurrentItem.id);
            return SCPCheck && WeaponCheck;
        }
    }
}