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
    public string weaponName;
    bool dead;

	// Use this for initialization
	void Start () {
        dead = false;
        agent = transform.GetComponent<UnityEngine.AI.NavMeshAgent>();
        enemyFound = false;
        wander = new wander(transform.gameObject,agent);
        attack = new attack(transform.gameObject, transform.parent.parent.Find("UserCharacter").gameObject,agent);
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

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == weaponName)
        {
            health -= 1;
        }
    }

}
