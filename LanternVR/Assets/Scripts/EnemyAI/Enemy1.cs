﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy1 : MonoBehaviour
{
    //private Animator _animator;

    private NavMeshAgent _navMeshAgent;

    public GameObject Player;

    public float AttackDistance = 10.0f;

    public float FollowDistance = 20.0f;

    [Range(0.0f, 1.0f)]
    public float AttackProbability = 0.5f;

    [Range(0.0f, 1.0f)]
    public float HitAccuracy = 0.5f;

    public int DamagePoints = 25;

   


    protected void Awake()
    {

        _navMeshAgent = GetComponent<NavMeshAgent>();

        //_animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (_navMeshAgent.enabled)
        {
            float dist = Vector3.Distance(Player.transform.position, this.transform.position);
            bool shoot = (dist < AttackDistance);
            bool follow = (dist < FollowDistance);

            if (follow)
            {
                float random = Random.Range(0.0f, 1.0f);
                if (random > (1.0f - AttackProbability) && dist < AttackDistance)
                {
                    shoot = true;
                }
            }

            if (follow)
            {
                _navMeshAgent.SetDestination(Player.transform.position);
            }

            if (!follow || shoot)
                _navMeshAgent.SetDestination(transform.position);

            if (shoot)
            {
                float random = Random.Range(0.0f, 1.0f);
                
                // The higher the accuracy is, the more likely the player will be hit
                bool isHit = random < HitAccuracy;
                random = Random.Range(0.0f, 1.0f);
                if (isHit && random < AttackProbability)
                {
                    Player.SendMessage("damage", DamagePoints);
                }
            }


            //_animator.SetBool("Shoot", shoot);
            //_animator.SetBool("Run", follow);

        }
    }
    /*
        public void ShootEvent()
        {
            if (m_Audio != null)
            {
                m_Audio.PlayOneShot(GunSound);
            }

            float random = Random.Range(0.0f, 1.0f);

            // The higher the accuracy is, the more likely the player will be hit
            bool isHit = random > 1.0f - HitAccuracy;

            if (isHit)
            {
                Player.SendMessage("Damage", DamagePoints, 
                    SendMessageOptions.DontRequireReceiver);
            }
        }

        public override void Die()
        {
            if (!enabled || !vp_Utility.IsActive(gameObject))
                return;

            if (m_Audio != null)
            {
                m_Audio.pitch = Time.timeScale;
                m_Audio.PlayOneShot(DeathSound);
            }

            _navMeshAgent.enabled = false;

            _animator.SetBool("IsFollow", false);
            _animator.SetBool("Attack", false);

            _animator.SetTrigger("Die");

            Destroy(GetComponent<vp_SurfaceIdentifier>());

        }

        https://www.youtube.com/watch?v=CHV1ymlw-P8  navmesh video


        */
}
