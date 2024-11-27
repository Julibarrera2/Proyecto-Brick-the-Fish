using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class wander : MonoBehaviour
{
    [SerializeField] private AudioClip dieSound, hitSound, habilitiesSound;

    NavMeshAgent agent;
    public Vector3[] corners;
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    
    void Start()
    {
        agent.destination = new Vector3(Random.Range(corners[0].x, corners[1].x), transform.position.y, Random.Range(corners[0].z, corners[1].z));
        GetComponent<Animator>().SetBool("walking", true);
    }
    void Update()
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
            agent.destination = new Vector3(Random.Range(corners[0].x, corners[1].x), transform.position.y, Random.Range(corners[0].z, corners[1].z));
    }
}
