using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//description: Controls Zombie AI
//IMPORTANT: Must be attached to object with rigidbody
public class robby : MonoBehaviour {
    wander wander;
    attack attack;
    UnityEngine.AI.NavMeshAgent agent;
    public bool enemyFound;
    public int health;
    bool dead;
    public float rechargetime;
    float previousattacktime;

	// Use this for initialization
	void Start () {
        previousattacktime = 0;
        dead = false;
        agent = transform.GetComponent<UnityEngine.AI.NavMeshAgent>();
        enemyFound = false;
        wander = new wander(transform.gameObject,agent);
        attack = new attack(transform.gameObject, transform.parent.parent.Find("UserCharacter").gameObject,agent);
   }

    public void takeDamage(){
        health -= 1;
        if (health <= 0)
        {
            agent.isStopped = true;
            Animator anim = GetComponent<Animator>();
            anim.Play("fallingback 0");
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            transform.GetComponent<Rigidbody>().isKinematic = true;
            Destroy(transform.Find("collider").gameObject);
            dead = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (dead)
        {
            return;
        }
        if (new vision().userFound(gameObject))
        {
            if (Time.time - previousattacktime > rechargetime){
                if (Mathf.Abs(transform.parent.parent.Find("UserCharacter").position.x-transform.position.x)<1){
                    if (Mathf.Abs(transform.parent.parent.Find("UserCharacter").position.z - transform.position.z) < 1)
                    {
                        previousattacktime = Time.time;
                        transform.parent.parent.Find("UserCharacter").GetComponent<Health>().numHearts -= 1;
                        Animator anim = GetComponent<Animator>();
                        anim.Play("attack 0");

                    }
                }
            }
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
        if (health <= 0)
        {
            agent.isStopped = true;
            Animator anim = GetComponent<Animator>();
            anim.Play("fallingback 0");
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            transform.GetComponent<Rigidbody>().isKinematic = true;
            Destroy(transform.Find("collider").gameObject);
            dead = true;
        }
    }

}
