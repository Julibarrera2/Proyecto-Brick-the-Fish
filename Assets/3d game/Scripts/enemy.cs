using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class enemy : MonoBehaviour
{
    int health = 20;
    public TextMeshProUGUI uiHealth;
    public GameManager gameManager;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("PostProcessing"))
        {
            Destroy(collision.gameObject);
            health -= 20;
            uiHealth.text = Mathf.Clamp(health, 0, 100).ToString();
        }
    }

    private void Update()
    {
        //GANAR
        if (health <= 0)
        {
            gameManager.StartCoroutine(gameManager.Win());
            Destroy(gameObject);
        }
    }
}
