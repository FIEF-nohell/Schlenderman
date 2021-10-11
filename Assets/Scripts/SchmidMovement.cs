using UnityEngine;
using UnityEngine.AI;

public class SchmidMovement : MonoBehaviour
{

    public Rigidbody player;
    public NavMeshAgent agent;

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.transform.position);
    }
}
