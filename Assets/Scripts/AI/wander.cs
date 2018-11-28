using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
//Description: Handles an AI in wandering mode
public class wander {

    float force;
    float velocity;
    float torque;
    Vector3 target;
    Vector3 origin;
    GameObject entity;
    float angleDifferenceAllowed;
    int travelRange;
    UnityEngine.AI.NavMeshAgent agent;
    public void set()
    {
        Vector3 random = UnityEngine.Random.insideUnitSphere * travelRange;
        random += entity.transform.position;
        UnityEngine.AI.NavMeshHit hit;
        UnityEngine.AI.NavMesh.SamplePosition(random, out hit, travelRange, 1);
        Vector3 finalPosition = hit.position;
        agent.SetDestination(finalPosition);
    }

    public wander(float force, float velocity, float torque, float angleDifferenceAllowed, GameObject entity, int travelRange, UnityEngine.AI.NavMeshAgent agent)
    {
        this.force = force;
        this.velocity = velocity;
        this.torque = torque;
        this.entity = entity;
        this.angleDifferenceAllowed = angleDifferenceAllowed;
        this.travelRange = travelRange;
        origin = entity.transform.position;
        System.Random rand = new System.Random();
        int x = (int)origin.x;
        int z = (int)origin.z;
        target = new Vector3(rand.Next(x-travelRange, x + travelRange),0, rand.Next(z-travelRange, z+travelRange));
        this.agent = agent;
        set();
    }

    public float AdjustAngle(float angle)
    {
        while (angle < 0)
        {
            angle += 360;
        }
        while (angle >= 360)
        {
            angle -= 360;
        }
        return angle;
    }

    bool GoClockwise(float angle1, float angle2)
    {
        angle1 = AdjustAngle(angle1);
        angle2 = AdjustAngle(angle2);
        if (angle1 > angle2)
        {
            if (angle1 - angle2 > 180)
                return true;
            else
            {
                return false;
            }
        }
        else
        {
            if (angle2 - angle1 < 180)
            {
                return true;
            }
            return false;
        }
    }

    bool RoundAngle(float angle1, float angle2)
    {
        angle1 = AdjustAngle(angle1 + 180f);
        angle2 = AdjustAngle(angle2);
        if (angle1 - angle2 < angleDifferenceAllowed && angle1 - angle2 > -angleDifferenceAllowed)
        {
            return true;
        }
        return false;
    }



    public void update(){
        if (Math.Abs(target.x-entity.transform.position.x)<1&& Math.Abs(target.z - entity.transform.position.z)<1){
            set();
        }
        //point point = new point(torque, angleDifferenceAllowed, target, entity);
        //point.pointTowardsTarget();
        //if (entity.transform.GetComponent<Rigidbody>().velocity.magnitude < velocity)
        //{
        //    entity.transform.GetComponent<Rigidbody>().AddRelativeForce(0, 0, force* Time.deltaTime);
        //}
    }
}
