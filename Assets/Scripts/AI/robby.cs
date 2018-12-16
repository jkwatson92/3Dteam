using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//description: Controls Zombie AI
//IMPORTANT: Must be attached to object with rigidbody
public class robby : MonoBehaviour {
    wander wander;
    attack attack;
    gotopoint gotopoint;
    UnityEngine.AI.NavMeshAgent agent;
    public float force;
    public float walkVelocity;
    public float torque;
    public float angleDifferenceAllowed;
    public int travelRange;
    public bool enemyFound;
    public Vector3 origin;

	// Use this for initialization
	void Start () {
        agent = transform.GetComponent<UnityEngine.AI.NavMeshAgent>();
        enemyFound = false;
        wander = new wander(force, walkVelocity, torque, angleDifferenceAllowed, transform.gameObject, travelRange,agent,origin,transform);
        attack = new attack(force, walkVelocity, torque, angleDifferenceAllowed, transform.gameObject, travelRange, transform.parent.parent.Find("UserCharacter").gameObject,agent);
        gotopoint = new gotopoint(force, walkVelocity, torque, angleDifferenceAllowed, transform.gameObject, travelRange, transform.parent.parent.Find("UserCharacter").gameObject.transform.position,agent);
    }
	
	// Update is called once per frame
	void Update () {
        if (new vision().userFound(gameObject))
        {
            attack.set();
            enemyFound = true;
        }
        else
        {
            if (enemyFound == false)
            {
                wander.update();
            }
         }
    }
}
