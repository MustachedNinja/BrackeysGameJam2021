using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void PlayLevel(int levelIndex) {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + levelIndex);
    }
    public void QuitGame() {
        // save any game data here
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
