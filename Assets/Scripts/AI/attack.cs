using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//Description: causes game object to head towards another character
public class attack {

    float force;
    float velocity;
    float torque;
    GameObject target;
    Vector3 origin;
    GameObject entity;
    float angleDifferenceAllowed;
    int travelRange;


    public attack(float force, float velocity, float torque, float angleDifferenceAllowed, GameObject entity, int travelRange, GameObject target)
    {
        this.force = force;
        this.velocity = velocity;
        this.torque = torque;
        this.entity = entity;
        this.angleDifferenceAllowed = angleDifferenceAllowed;
        this.travelRange = travelRange;
        this.target = target;
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

    public void update()
    {
        point point = new point(torque, angleDifferenceAllowed, target.transform.position, entity);
        point.pointTowardsTarget();
        if (entity.transform.GetComponent<Rigidbody>().velocity.magnitude < velocity)
        {
            entity.transform.GetComponent<Rigidbody>().AddRelativeForce(0, 0, force * Time.deltaTime);
        }
    }
}
