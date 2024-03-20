using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_W6 : MonoBehaviour
{
    public List<Transform> PatrolPoints;
    public Transform Player;
    public float ViewAngle = 90;
    public float MinDetectDistance = 3;
    public float Damage = 10;

    NavMeshAgent _navMeshAgent;
    PlayerHealth _playerHealth;

    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _playerHealth = Player.GetComponent<PlayerHealth>();
    }

    void Update()
    {
        if (CheckPlayer())
        {
            _navMeshAgent.SetDestination(Player.position);
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                Debug.Log("Player in range");
                _playerHealth.TakeDamage(Damage * Time.deltaTime);
            }
        }
        else
        {
            Patrol();
        }
    }

    bool CheckPlayer()
    {
        Vector3 direction = Player.position - transform.position;
        if (Vector3.Angle(transform.forward, direction) < ViewAngle || Vector3.Distance(transform.position, Player.position) < MinDetectDistance)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.transform == Player)
                {
                    return true;
                }
            }
        }
        return false;
    }

    void Patrol()
    {
        if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
        {
            _navMeshAgent.SetDestination(PatrolPoints[Random.Range(0, PatrolPoints.Count)].position);
        }
    }
}
