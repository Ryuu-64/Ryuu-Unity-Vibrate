using UnityEngine;

namespace Ryuu.Unity.Vibrate.Android
{
    public class AndroidVibrator : IVibrator
    {
        private readonly AndroidJavaObject vibratorObject;

        public AndroidVibrator()
        {
            AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            vibratorObject = currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator");
        }

        public void Vibrate(VibrateArgs vibrateArgs)
        {
            AndroidJavaObject vibrationEffect =
                AndroidVibrationEffect.CreateOneShot(vibrateArgs.Time, vibrateArgs.Amplitude);
            vibratorObject.Call("vibrate", vibrationEffect);
        }

        public void Cancel()
        {
            vibratorObject.Call("cancel");
        }
    }
}