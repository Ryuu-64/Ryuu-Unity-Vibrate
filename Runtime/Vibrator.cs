using Ryuu.Unity.Vibrate.Android;
using Ryuu.Unity.Vibrate.Unity;
using UnityEngine;

namespace Ryuu.Unity.Vibrate
{
    public class Vibrator : IVibrator
    {
        private readonly IVibrator vibrator;

        public Vibrator()
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                vibrator = new AndroidVibrator();
            }
            else
            {
                vibrator = new UnityVibrator();
            }
        }

        public void Vibrate(VibrateArgs vibrateArgs)
        {
            vibrator.Vibrate(vibrateArgs);
        }

        public void Cancel()
        {
            vibrator.Cancel();
        }
    }
}