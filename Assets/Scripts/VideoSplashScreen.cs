using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoSplashScreen : MonoBehaviour
{
    // Nama scene berikutnya
    public string nextSceneName;

    private VideoPlayer videoPlayer;

    private void Start()
    {
        // Ambil komponen VideoPlayer
        videoPlayer = GetComponent<VideoPlayer>();

        // Pastikan VideoPlayer ada
        if (videoPlayer == null)
        {
            Debug.LogError("VideoPlayer tidak ditemukan di GameObject ini!");
            return;
        }

        // Daftarkan callback untuk event selesai video
        videoPlayer.loopPointReached += OnVideoFinished;
    }

    private void OnVideoFinished(VideoPlayer vp)
    {
        // Ganti ke scene berikutnya
        SceneManager.LoadScene(nextSceneName);
    }
}
