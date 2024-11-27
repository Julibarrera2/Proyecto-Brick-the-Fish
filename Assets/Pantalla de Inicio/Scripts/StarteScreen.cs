using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarteScreen : MonoBehaviour
{
    [SerializeField] private AudioClip startSound;
    public void StartGame()
    {
        AudioManager.Instance.PlaySound(startSound);
    }
}
