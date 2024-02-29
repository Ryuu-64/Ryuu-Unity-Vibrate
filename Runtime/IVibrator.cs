namespace Ryuu.Unity.Vibrate
{
    public interface IVibrator
    {
        public void Vibrate(VibrateArgs vibrateArgs);
        public void Cancel();
    }
}