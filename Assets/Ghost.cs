using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public Transform[] points;
    private int destPoint = 0;
    private UnityEngine.AI.NavMeshAgent agent;

    private GameObject[] coins;
    private GameObject[] ghosts;

    void Start () {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        
        if (coins == null) {
            coins = GameObject.FindGameObjectsWithTag("coin");
        }
            
        foreach (GameObject coin in coins)
        {
            Physics.IgnoreCollision(coin.GetComponent<Collider>(), GetComponent<Collider>());
        }

        if (ghosts == null) {
            ghosts = GameObject.FindGameObjectsWithTag("Ghost");
        }
            
        foreach (GameObject ghost in ghosts)
        {
            Physics.IgnoreCollision(ghost.GetComponent<Collider>(), GetComponent<Collider>());
        }

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;

        GotoNextPoint();
    }


    void GotoNextPoint() {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }


    void Update () {
        // Choose the next destination point when the agent gets
        // close to the current one.
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();
    }

}

