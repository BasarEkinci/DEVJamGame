using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class VirusMovementController : MonoBehaviour
{
    public float wanderRadius;
    public float wanderTimer;
 
    private Transform target;
    private NavMeshAgent agent;
    private float timer;
    private bool isEnable = false;

    void Awake() 
    {
        agent = GetComponent<NavMeshAgent> ();
        timer = wanderTimer;
    }
    
    void OnEnable () 
    {
        timer += Time.deltaTime;
        if (timer >= wanderTimer)
        {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius,-1);
            agent.SetDestination(newPos);
            timer = 0;
        }
        isEnable = true;
    }

    private void Update()
    {
        if (isEnable)
        {
            timer += Time.deltaTime;
            if (timer >= wanderTimer)
            {
                Vector3 newPos = RandomNavSphere(transform.position, wanderRadius,-1); 
                agent.SetDestination(newPos);
                timer = 0;
            }
        }
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask) 
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;
 
        randDirection += origin;
 
        NavMeshHit navHit;
 
        NavMesh.SamplePosition (randDirection, out navHit, dist, layermask);
 
        return navHit.position;
    }
}
