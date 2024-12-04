using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit!");
    }
}