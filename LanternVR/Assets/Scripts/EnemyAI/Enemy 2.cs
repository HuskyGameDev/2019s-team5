using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy2 : MonoBehaviour {

    private NavMeshAgent _navMeshAgent;
    private Collider sight;

    private RaycastHit hit;
    public float AttackDistance = 10.0f;

    public float FollowDistance = 20.0f;

    [Range(0.0f, 1.0f)]
    public float AttackProbability = 0.5f;

    [Range(0.0f, 1.0f)]
    public float HitAccuracy = 0.5f;

    public float DamagePoints = 2.0f;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        sight = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            Physics.Raycast(transform.position, other.transform.position - transform.position, out hit);
            
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
