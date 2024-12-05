using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class enemy : MonoBehaviour
{
    [SerializeField] private AudioClip dieSound, hitSound;
    int health = 100;
    public TextMeshProUGUI uiHealth;
    public TextMeshProUGUI uiTimer;
    public GameManager gameManager;
    float time = 10f;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("PostProcessing"))
        {
            Destroy(collision.gameObject);
            health -= 20;
            uiHealth.text = Mathf.Clamp(health, 0, 100).ToString();
            AudioManager.Instance.PlaySound(hitSound);
        }
    }

    private void Update()
    {
        time -= Time.deltaTime;
        uiTimer.text = ((int)(time / 60)).ToString() + ":" + (Mathf.Clamp((int)(time % 60), 0 , 60)).ToString("D2");
        if (health <= 0)
        {
            gameManager.StartCoroutine(gameManager.Win());
            Destroy(gameObject);
            AudioManager.Instance.PlaySound(dieSound);
        }
        if (time <= 0) SceneManager.LoadSceneAsync("perder1");
    }
}
