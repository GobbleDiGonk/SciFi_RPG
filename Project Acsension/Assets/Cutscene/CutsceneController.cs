using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class CutsceneController : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer.loopPointReached += OnCutsceneEnd;
    }

    void OnCutsceneEnd(VideoPlayer vp)
    {
        SceneManager.LoadScene("MainGame");
    }

    public void SkipCutscene()
    {
        SceneManager.LoadScene("MainGame");
    }
}
