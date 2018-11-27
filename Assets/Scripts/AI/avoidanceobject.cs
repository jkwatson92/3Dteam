using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Description: Attaches to game object that functions as sensor for nearby objects to avoid
//IMPORTANT: In order for obstacle avoidance to work, game object with collider must have this attached
public class avoidanceobject : MonoBehaviour {


    private void OnTriggerEnter(Collider other)
    {
        if (other.name != "UserCollider")
        {
            transform.name = "avoidTarget";
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name != "UserCollider")
        {
            transform.name = "avoidTarget";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name != "UserCollider")
        {
            transform.name = "avoidance";
        }
    }
}
