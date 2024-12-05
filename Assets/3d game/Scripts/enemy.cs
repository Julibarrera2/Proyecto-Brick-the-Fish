  using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class enemy : MonoBehaviour
{
    [SerializeField] private AudioClip dieSound, hitSound;
    int health = 100;
    public TextMeshProUGUI uiHealth;
    public GameManager gameManager;
    public GameObject[] otherEnemies;
    int totalHealth = 300;
    bool alone;

    private void Start()
    {
        if (otherEnemies == null) alone = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("PostProcessing"))
        {
            Destroy(collision.gameObject);
            health -= 20;
            GetComponent<Animator>().SetTrigger("hit");
            if (alone) uiHealth.text = Mathf.Clamp(health, 0, 100).ToString();
            else
            {
                totalHealth = health;
                foreach (GameObject enemy in otherEnemies) if (enemy != null) totalHealth += enemy.GetComponent<enemy>().health;
                uiHealth.text = Mathf.Clamp(totalHealth, 0, 300).ToString();
            }
            AudioManager.Instance.PlaySound(hitSound);
        }
    }

    private void Update()
    {
        if (health <= 0)
        {
            AudioManager.Instance.PlaySound(dieSound);
            Destroy(gameObject);
            if (!alone && int.Parse(uiHealth.text) <= 0) gameManager.StartCoroutine(gameManager.Win());
        }
    }
}
