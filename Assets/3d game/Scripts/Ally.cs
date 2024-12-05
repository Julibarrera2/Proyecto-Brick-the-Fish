﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ally : MonoBehaviour
{
    public GameObject[] targets;
    GameObject target;
    float timer = 0f;
    public GameObject brick;
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            retry:
            if (targets == null) Destroy(this);
            target = targets[Random.Range(0, 3)];
            if (target == null) goto retry;
            transform.LookAt(target.transform);
            GetComponent<Animator>().SetTrigger("throw");
            Instantiate(brick, transform.position + new Vector3(-1.5f, 7, 0), Quaternion.identity).GetComponent<Rigidbody>().AddForce(transform.forward * 500, ForceMode.Impulse);
            timer = 3f;
        }
    }
}
