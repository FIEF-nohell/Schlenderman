using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class SchmidMovement : MonoBehaviour
{

    public Rigidbody player;
    public NavMeshAgent agent;
    public GameObject schmid;
    private RaycastHit ray;
    public float multiplier;
    public float IdleSpeed;
    public float ChaseSpeed;
    public float rayLength;
    public float rayAngle;
    public bool Seen;
    

    void Update()
    {
        Debug.DrawRay(schmid.transform.position, schmid.transform.forward * rayLength, Color.red, 0.3f);

        if(Physics.Raycast(schmid.transform.position, schmid.transform.forward, out ray, rayLength))
        {
            if(ray.collider.tag == "Player"){
                agent.speed = ChaseSpeed * multiplier;
                Seen = true;
                StartCoroutine(ChangeSpeed(5));
            }
        }
        else{
            if(Seen == false) agent.speed = IdleSpeed * multiplier;            
        }

        agent.SetDestination(player.transform.position);
    }

    IEnumerator ChangeSpeed(int num){

        for(int i = 0; i < num; i++){
            agent.speed = ChaseSpeed * multiplier;
            yield return new WaitForSeconds(1.0f);
        }
        Seen = false;
        StopAllCoroutines();
        
    }

}
