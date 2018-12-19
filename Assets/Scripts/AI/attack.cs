using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//Description: causes game object to head towards another character
public class attack {


    GameObject target;
    UnityEngine.AI.NavMeshAgent agent;


    public attack(GameObject entity, GameObject target, UnityEngine.AI.NavMeshAgent agent)
    {
        this.target = target;
        this.agent = agent;
    }

    public void update()
    {
        agent.SetDestination(target.transform.position);
    }

    public void set(){
        agent.SetDestination(target.transform.position);
    }
}
