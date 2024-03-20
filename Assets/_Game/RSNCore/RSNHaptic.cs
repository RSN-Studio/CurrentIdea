using Lofelt.NiceVibrations;

namespace _Game.RSNCore
{
    public static class RsnHaptic
    {
        public static void Failed() => HapticPatterns.PlayPreset(HapticPatterns.PresetType.Failure);

        public static void Success() => HapticPatterns.PlayPreset(HapticPatterns.PresetType.Success);

        public static void Selection() => HapticPatterns.PlayPreset(HapticPatterns.PresetType.Selection);

        public static void Warning() => HapticPatterns.PlayPreset(HapticPatterns.PresetType.Warning);

        public static void LightImpact() => HapticPatterns.PlayPreset(HapticPatterns.PresetType.LightImpact);

        public static void SoftImpact() => HapticPatterns.PlayPreset(HapticPatterns.PresetType.SoftImpact);

        public static void MediumImpact() => HapticPatterns.PlayPreset(HapticPatterns.PresetType.MediumImpact);

        public static void HeavyImpact() => HapticPatterns.PlayPreset(HapticPatterns.PresetType.HeavyImpact);

        public static void EnableHaptics(bool isEnabled = true) => HapticController.hapticsEnabled = isEnabled;

        public static void PlayHapticPreset(HapticPatterns.PresetType type) => HapticPatterns.PlayPreset(type);
    }
}