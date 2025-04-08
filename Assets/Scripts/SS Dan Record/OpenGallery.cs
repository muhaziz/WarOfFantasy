using UnityEngine;

public class OpenGallery : MonoBehaviour
{
    public void OpenGalleryApp()
    {
#if UNITY_ANDROID
        try
        {
            using (AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            {
                AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
                AndroidJavaObject packageManager = currentActivity.Call<AndroidJavaObject>("getPackageManager");

                // Daftar paket galeri yang akan dicoba
                string[] galleryPackages = {
                    "com.android.gallery3d",         // Galeri bawaan Android
                    "com.google.android.apps.photos", // Google Photos
                    "com.sec.android.gallery3d",     // Galeri Samsung
                    "com.miui.gallery",              // Galeri Xiaomi
                    "com.oppo.gallery",              // Galeri Oppo
                    "com.coloros.gallery3d",         // Galeri Realme/Oppo ColorOS
                    "com.realme.gallery3d",          // Galeri Realme (khusus)
                    "com.huawei.photos",             // Galeri Huawei
                    "com.vivo.gallery",              // Galeri Vivo
                    "com.asus.gallery",              // Galeri Asus
                    "com.sonyericsson.album",        // Album Sony
                    "com.lge.gallery",               // Galeri LG
                    "com.htc.album",                 // Galeri HTC
                    "com.lenovo.scg",                // Galeri Lenovo
                    "com.meizu.media.gallery",       // Galeri Meizu
                    "com.zte.gallery3d",             // Galeri ZTE
                    "com.oneplus.gallery",           // Galeri OnePlus
                    "com.nubia.gallery",             // Galeri Nubia
                    "com.motorola.MotGallery2",      // Galeri Motorola
                    "com.alcatel.gallery3d",         // Galeri Alcatel
                    "com.transsion.gallery3d",       // Galeri Transsion (Infinix, Tecno, Itel)
                    "com.wiko.gallery3d",            // Galeri Wiko
                    "com.hmdglobal.app.gallery",     // Galeri Nokia
                    "com.micromax.gallery",          // Galeri Micromax
                    "com.intex.gallery3d"            // Galeri Intex
                };



                AndroidJavaObject intent = null;

                // Coba temukan salah satu aplikasi galeri
                foreach (string packageName in galleryPackages)
                {
                    intent = packageManager.Call<AndroidJavaObject>("getLaunchIntentForPackage", packageName);
                    if (intent != null)
                    {
                        break; // Jika intent ditemukan, keluar dari loop
                    }
                }

                if (intent != null)
                {
                    currentActivity.Call("startActivity", intent);
                }
                else
                {
                    Debug.LogError("No gallery app found!");
                }
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error launching gallery: " + e.Message);
        }
#else
        Debug.Log("Gallery can only be opened on an Android device.");
#endif
    }
}
