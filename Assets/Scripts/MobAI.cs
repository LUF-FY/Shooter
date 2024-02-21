using UnityEngine;
using UnityEngine.AI;

public class MobAI : MonoBehaviour
{
    public Transform Target;

    private NavMeshAgent _agent;


    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        
    }

    void Update()
    {
        _agent.destination = Target.position;
    }
}
