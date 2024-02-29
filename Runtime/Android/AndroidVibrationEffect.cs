using System.Collections;
using UnityEngine;

namespace Ryuu.Unity.Vibrate.Android
{
    public static class AndroidVibrationEffect
    {
        static AndroidVibrationEffect()
        {
            if (Application.platform != RuntimePlatform.Android)
            {
                return;
            }

            if (!IsSupportVibrationEffect)
            {
                return;
            }

            VibrationEffectClass = new AndroidJavaClass("android.os.VibrationEffect");
            DefaultAmplitude = VibrationEffectClass.GetStatic<int>("DEFAULT_AMPLITUDE");
            EffectClick = new PredefinedEffect(
                VibrationEffectClass.GetStatic<int>("EFFECT_CLICK"),
                "EFFECT_CLICK"
            );
            EffectDoubleClick = new PredefinedEffect(
                VibrationEffectClass.GetStatic<int>("EFFECT_DOUBLE_CLICK"),
                "EFFECT_DOUBLE_CLICK"
            );
            EffectHeavyClick = new PredefinedEffect(
                VibrationEffectClass.GetStatic<int>("EFFECT_HEAVY_CLICK"),
                "EFFECT_HEAVY_CLICK"
            );
            EffectTick = new PredefinedEffect(
                VibrationEffectClass.GetStatic<int>("EFFECT_TICK"),
                "EFFECT_TICK"
            );
        }

        public static readonly int DefaultAmplitude;
        public static readonly PredefinedEffect EffectClick;
        public static readonly PredefinedEffect EffectDoubleClick;
        public static readonly PredefinedEffect EffectHeavyClick;
        public static readonly PredefinedEffect EffectTick;
        public static readonly bool IsSupportPredefinedEffect = AndroidBuildVersion.SDKInt >= 29;
        private static readonly bool IsSupportVibrationEffect = AndroidBuildVersion.SDKInt >= 26;
        private static readonly AndroidJavaClass VibrationEffectClass;

        public static AndroidJavaObject CreateOneShot(long milliseconds, int amplitude) =>
            VibrationEffectClass.CallStatic<AndroidJavaObject>("createOneShot", milliseconds, amplitude);

        public static AndroidJavaObject CreatePredefined(PredefinedEffect predefinedEffect) =>
            VibrationEffectClass.CallStatic<AndroidJavaObject>("createPredefined", predefinedEffect.id);

        public static AndroidJavaObject CreateWaveform(IEnumerable timings, IEnumerable amplitudes, int repeat) =>
            VibrationEffectClass.CallStatic<AndroidJavaObject>("createWaveform", timings, amplitudes, repeat);

        public static AndroidJavaObject CreateWaveform(IEnumerable timings, int repeat) =>
            VibrationEffectClass.CallStatic<AndroidJavaObject>("createWaveform", timings, repeat);

        public class PredefinedEffect
        {
            public readonly int id;
            public readonly string name;

            public PredefinedEffect(int id, string name)
            {
                this.id = id;
                this.name = name;
            }
        }
    }
}