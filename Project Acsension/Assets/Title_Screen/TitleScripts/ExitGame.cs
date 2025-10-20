using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // quit in editor
        #else
        Application.Quit(); // quit in game
        #endif
    }
}
