namespace Ryuu.Unity.Vibrate
{
    public class VibrateArgs
    {
        /// <summary>
        /// in milliseconds
        /// </summary>
        public int Time { get; set; } = -1;

        /// <summary>
        /// [1, 255] in Android
        /// </summary>
        public int Amplitude { get; set; } = -1;

        public override string ToString()
        {
            return $"VibrateArgs{{Time={Time}, Amplitude={Amplitude}}}";
        }
    }
}