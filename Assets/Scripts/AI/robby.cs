using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//description: Controls Zombie AI
//IMPORTANT: Must be attached to object with rigidbody
public class robby : MonoBehaviour {
    wander wander;
    attack attack;
    gotopoint gotopoint;
    public float force;
    public float walkVelocity;
    public float torque;
    public float angleDifferenceAllowed;
    public int travelRange;
    public bool enemyFound;

	// Use this for initialization
	void Start () {
        enemyFound = false;
        wander = new wander(force, walkVelocity, torque, angleDifferenceAllowed, transform.gameObject, travelRange);
        attack = new attack(force, walkVelocity, torque, angleDifferenceAllowed, transform.gameObject, travelRange, transform.parent.Find("UserCharacter").gameObject);
        gotopoint = new gotopoint(force, walkVelocity, torque, angleDifferenceAllowed, transform.gameObject, travelRange, transform.parent.Find("UserCharacter").gameObject.transform.position);
    }
	
	// Update is called once per frame
	void Update () {
        if (!new avoidance().objectInWay(gameObject)){
            if (new vision().userFound(gameObject))
            {
                attack.update();
                enemyFound = true;
            }
            else
            {
                if (enemyFound == true)
                {
                    enemyFound = gotopoint.update();
                }
                else
                {
                    wander.update();
                }
            }
        }
        else{
            new avoidance().avoid(gameObject, torque);
        }
    }
}
