using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class enemy : MonoBehaviour
{
    [SerializeField] private AudioClip dieSound, hitSound;
    int health = 100;
    public TextMeshProUGUI uiHealth;
    public TextMeshProUGUI uiTimer;
    public GameManager gameManager;
    float time = 180f;
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
        uiTimer.text = (time / 60).ToString() + ":" + (time % 60).ToString();
        //GANAR
        if (health <= 0)
        {
            gameManager.StartCoroutine(gameManager.Win());
            Destroy(gameObject);
            AudioManager.Instance.PlaySound(dieSound);
        }
    }
}
