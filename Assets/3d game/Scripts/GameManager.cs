using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI uiTimer;
    float time = 180f;
    bool ended;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (!ended)
        {
            time -= Time.deltaTime;
            uiTimer.text = ((int)(time / 60)).ToString() + ":" + (Mathf.Clamp((int)(time % 60), 0, 60)).ToString("D2");
            if (time <= 0) SceneManager.LoadSceneAsync("perder");
        }
    }

    public IEnumerator Win()
    {
        ended = true;
        yield return new WaitForSeconds(3);
        if (SceneManager.GetActiveScene().name == "1") SceneManager.LoadSceneAsync("ganar1");
        if (SceneManager.GetActiveScene().name == "2") SceneManager.LoadSceneAsync("ganar2");
        if (SceneManager.GetActiveScene().name == "3") SceneManager.LoadSceneAsync("ganar3");
    }
}