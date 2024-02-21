using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> patrolPoints;
    public PlayerController player;

    private NavMeshAgent _navMeshAgent;
    private bool _isplayerNoticed;
    private float viewAngle;

    // Start is called before the first frame update
    void Start()
    {
        InitComponentLinks();
        PickNewPatrolPoint();
    }

    private void InitComponentLinks()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        NoticePlayerUpdate();
        ChaseUpdate();
        PatrolUpdate();
    }

    private void ChaseUpdate()
    {
        if (_isplayerNoticed) _navMeshAgent.destination = player.transform.position;
    }

    private void NoticePlayerUpdate()
    {
        var direction = player.transform.position - transform.position;
        _isplayerNoticed = false;
        if (Vector3.Angle(transform.position, direction) < viewAngle)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == player.gameObject)
                {
                    _isplayerNoticed = true;
                }
            }
        }
    }

    private void PatrolUpdate()
    {
        if (!_isplayerNoticed)
        {
            if (_navMeshAgent.remainingDistance == 0)
            {
                PickNewPatrolPoint();
            }
        }
    }

    private void PickNewPatrolPoint()
    {
        _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
    }
}
