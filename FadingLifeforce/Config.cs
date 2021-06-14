using Exiled.API.Enums;
using System.ComponentModel;
using Exiled.API.Interfaces;
using System.Collections.Generic;

namespace FadingLifeforce
{
    public sealed class Config : IConfig
    {
        [Description("Whether or not the plugin should be enabled on this server.")]
        public bool IsEnabled { get; set; } = true;

        [Description("Whether or not SCPs should be given status effects when they are shot.")]
        public bool EffectOnShotAffectScps { get; set; } = false;

        [Description("A list of effects that could be inflicted when a player is shot, the % chance that it will happen, and the duration of the effect.")]
        public Dictionary<EffectType, float[]> EffectOnShot { get; set; } = new Dictionary<EffectType, float[]>
        {
            { EffectType.Bleeding, new float[2]{ 90, 15 } }
        };

        [Description("A list of effects that could be inflicted when a player falls, the % chance that it will happen, and the duration of the effect.")]
        public Dictionary<EffectType, float[]> EffectOnFall { get; set; } = new Dictionary<EffectType, float[]>
        {
            { EffectType.Disabled, new float[2]{ 5, 30 } }
        };

        [Description("A list of effects that could be inflicted when a player enters the PD, the % chance that it will happen, and the duration of the effect.")]
        public Dictionary<EffectType, float[]> EffectOnPdEnter { get; set; } = new Dictionary<EffectType, float[]>
        {
            { EffectType.Panic, new float[2]{ 100, 60 } }
        };

        [Description("A list of effects that could be inflicted when a player is hurt by an SCP, the % chance that it will happen, and the duration of the effect.")]
        public Dictionary<EffectType, float[]> EffectOnHurtByScp { get; set; } = new Dictionary<EffectType, float[]>
        {
            { EffectType.Panic, new float[2]{ 100, 20 } }
        };
    }
}