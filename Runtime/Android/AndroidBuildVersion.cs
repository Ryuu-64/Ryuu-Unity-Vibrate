using UnityEngine;

namespace Ryuu.Unity.Vibrate.Android
{
    public static class AndroidBuildVersion
    {
        static AndroidBuildVersion()
        {
            if (Application.platform != RuntimePlatform.Android)
            {
                return;
            }

            AndroidJavaClass buildVersionClass = new AndroidJavaClass("android.os.Build$VERSION");
            SDKInt = buildVersionClass.GetStatic<int>("SDK_INT");
        }

        public static readonly int SDKInt;
    }
}