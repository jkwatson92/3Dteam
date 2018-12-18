using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
//Description: Handles an AI in wandering mode
public class wander {


    Vector3 target;
    GameObject entity;
    UnityEngine.AI.NavMeshAgent agent;
    float timer;
    float starttime;
    public void set()
    {

        var random = new System.Random();
        int value = random.Next(0, entity.transform.parent.childCount);
        UnityEngine.AI.NavMeshHit hit;
        UnityEngine.AI.NavMesh.SamplePosition(entity.transform.parent.GetChild(value).transform.position, out hit,1,1);
        Vector3 finalPosition = hit.position;
        agent.SetDestination(finalPosition);
        target = finalPosition;
    }

    public wander(GameObject entity, UnityEngine.AI.NavMeshAgent agent)
    {
        this.timer = 0;
        this.starttime = Time.deltaTime;
        this.entity = entity;
        this.agent = agent;
        set();
    }



    public void update(){
        timer += Time.deltaTime - starttime;
        if (Math.Abs(target.x-entity.transform.position.x)<1&& Math.Abs(target.z - entity.transform.position.z)<1){
            set();
        }
        else if(timer>5){
            starttime = Time.deltaTime;
            timer = 0;
            set();
        }

    }
}
