using System.Collections;
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
            if (targets == null || AreAllTargetsNull()) Destroy(this);
            target = GetRandomValidTarget();
            if (target != null)
            {
                transform.LookAt(target.transform);
                GetComponent<Animator>().SetTrigger("throw");
                Instantiate(brick, transform.position + new Vector3(-1.5f, 7, 0), Quaternion.identity).GetComponent<Rigidbody>().AddForce(transform.forward * 500, ForceMode.Impulse);
                timer = 3f;
            }
        }
    }

    private bool AreAllTargetsNull()
    {
        foreach (var obj in targets) if (obj != null) return false;
        return true;
    }

    private GameObject GetRandomValidTarget()
    {
        List<GameObject> validTargets = new List<GameObject>();
        foreach (var obj in targets) if (obj != null) validTargets.Add(obj);
        if (validTargets.Count > 0) return validTargets[Random.Range(0, validTargets.Count)];
        return null;
    }
}
