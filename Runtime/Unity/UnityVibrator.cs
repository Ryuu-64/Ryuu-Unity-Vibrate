using UnityEngine;

namespace Ryuu.Unity.Vibrate.Unity
{
    public class UnityVibrator : IVibrator
    {
        public void Vibrate(VibrateArgs vibrateArgs)
        {
            Handheld.Vibrate();
        }

        public void Cancel()
        {
            Debug.LogWarning("Handheld doesn't support cancel vibrate.");
        }
    }
}