using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class SchmidMovement : MonoBehaviour
{
    public Camera main;
    public Camera second;
    public Rigidbody player;
    public NavMeshAgent agent;
    public GameObject schmid;
    private RaycastHit ray;
    public float multiplier;
    public int FasterForSeconds;
    public float IdleSpeed;
    public float ChaseSpeed;
    public float rayLength;
    public float rayAngle;
    public bool Seen;
    public AudioSource jumpscare;
    public AudioClip ses;
    

    void Update()
    {
        Debug.DrawRay(schmid.transform.position, schmid.transform.forward * rayLength, Color.red, 10);
        
        if(Physics.Raycast(schmid.transform.position, schmid.transform.forward, out ray, rayLength))
        {
            if(ray.collider.tag == "Player"){
                agent.speed = ChaseSpeed * multiplier;
                Seen = true;
                StartCoroutine(ChangeSpeed(FasterForSeconds));
            }
        }
        else{

            if (Seen == false) agent.speed = IdleSpeed * multiplier;            
        }
        
        agent.SetDestination(player.transform.position);
    }

    void Top3ScariestJumpscares()
    {
        jumpscare.PlayOneShot(ses);
        second.enabled = true;
        main.enabled = false;
        UIController.nummer = 69;
    }

    IEnumerator ChangeSpeed(int num){

        for(int i = 0; i < num; i++){
            agent.speed = ChaseSpeed * multiplier;
            if (agent.remainingDistance <= 3) Top3ScariestJumpscares();
            yield return new WaitForSeconds(1.0f);
        }
        Seen = false;
        StopAllCoroutines();        
    }
}
