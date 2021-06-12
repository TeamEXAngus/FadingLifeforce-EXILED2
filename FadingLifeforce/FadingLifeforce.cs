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
        private static FadingLifeforce singleton = new FadingLifeforce();
        public static FadingLifeforce Instance => singleton;
        public override PluginPriority Priority { get; } = PluginPriority.Medium;

        public override Version RequiredExiledVersion { get; } = new Version(2, 10, 0);
        public override Version Version { get; } = new Version(1, 0, 0);

        private Handlers.Hurting hurting;
        private Handlers.EnteringPD enteringPD;

        public Random RNG = new Random();

        private FadingLifeforce()
        {
        }

        //Run startup code when plugin is enabled
        public override void OnEnabled()
        {
            RegisterEvents();
        }

        //Run shutdown code when plugin is disabled
        public override void OnDisabled()
        {
            UnregisterEvents();
        }

        //Plugin startup code
        public void RegisterEvents()
        {
            hurting = new Handlers.Hurting();
            enteringPD = new Handlers.EnteringPD();

            PlayerHandler.Hurting += hurting.OnHurting;
            PlayerHandler.EnteringPocketDimension += enteringPD.OnEnteringPD;
        }

        //Plugin shutdown code
        public void UnregisterEvents()
        {
            PlayerHandler.Hurting -= hurting.OnHurting;
            PlayerHandler.EnteringPocketDimension -= enteringPD.OnEnteringPD;

            hurting = null;
            enteringPD = null;
        }

        public static void AddEffects(Dictionary<EffectType, float[]> dict, Player player)
        {
            foreach (var kvp in dict)
            {
                if (kvp.Value[0] > Instance.RNG.Next(1, 101))
                {
                    player.EnableEffect(kvp.Key, kvp.Value[1]);
                }
            }
        }
    }
}