using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scenes : MonoBehaviour
{
    public Image background;
    private void Update()
    {
        if (background.sprite.name == "END" && Input.GetKeyDown(KeyCode.R)) SceneManager.LoadSceneAsync("1");
    }
}
