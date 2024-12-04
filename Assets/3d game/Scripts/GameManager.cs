using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        Cursor.visible = false;
    }

    public IEnumerator Win()
    {
        yield return new WaitForSeconds(3);
        if (SceneManager.GetActiveScene().name == "1") SceneManager.LoadSceneAsync("ganar1");
    }
}
