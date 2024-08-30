using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteSwitcher : MonoBehaviour
{
    public bool IsSwitched = false;
    public Image image1;
    public Image image2;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    public void SwitchImage(Sprite sprite)
    {
        if (!IsSwitched)
        {
            image2.sprite = sprite;
            animator.SetTrigger("SwitchFirst");
        }
        else
        {
            image1.sprite = sprite;
            animator.SetTrigger("SwitchSecond");
        }
        IsSwitched = !IsSwitched;
    }


    public void SetImage(Sprite sprite)
    {
        if (!IsSwitched)
        {
            image1.sprite = sprite;
        }
        else
        {
            image2.sprite = sprite;
        }
    }
}
