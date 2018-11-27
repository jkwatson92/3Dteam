using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//Description: Causes a game object to head towards a given point
public class gotopoint {

    float force;
    float velocity;
    float torque;
    Vector3 target;
    Vector3 origin;
    GameObject entity;
    float angleDifferenceAllowed;
    int travelRange;


    public gotopoint(float force, float velocity, float torque, float angleDifferenceAllowed, GameObject entity, int travelRange, Vector3 target)
    {
        this.force = force;
        this.velocity = velocity;
        this.torque = torque;
        this.entity = entity;
        this.angleDifferenceAllowed = angleDifferenceAllowed;
        this.travelRange = travelRange;
        origin = entity.transform.position;
        this.target = target;
        //Debug.Log("x" + target.x);
        //Debug.Log("z" + target.z);
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

    public bool update()
    {
        if (Math.Abs(target.x - entity.transform.position.x) < 1 && Math.Abs(target.z - entity.transform.position.z) < 1)
        {
            return false;
        }
        point point = new point(torque, angleDifferenceAllowed, target, entity);
        point.pointTowardsTarget();
        if (entity.transform.GetComponent<Rigidbody>().velocity.magnitude < velocity)
        {
            entity.transform.GetComponent<Rigidbody>().AddRelativeForce(0, 0, force * Time.deltaTime);
        }
        return true;
    }
}
