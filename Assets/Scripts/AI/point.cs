using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//description: points a game object towards a target
public class point {
    float torque;
    GameObject entity;
    float targetAngle;
    float angleDifferenceAllowed;

    public point(float torque, float angleDifferenceAllowed, Vector3 targetPosition, GameObject entity){
        this.torque = torque;
        this.angleDifferenceAllowed = angleDifferenceAllowed;
        float xdistance = -(targetPosition.x - entity.transform.position.x);
        float zdistance = targetPosition.z - entity.transform.position.z;
        targetAngle = Mathf.Atan2(zdistance, xdistance) * Mathf.Rad2Deg;
        targetAngle -= 90;
        this.entity = entity;
        //Debug.Log("x" + targetPosition.x);
        //Debug.Log("z" + targetPosition.z);
        //Debug.Log("current y:" + entity.transform.rotation.eulerAngles.y);
        //Debug.Log("target y:" + targetAngle);
    }


    public float adjustAngle(float angle){
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

    bool goClockwise(){
        float angle1 = adjustAngle(entity.transform.rotation.eulerAngles.y);
        float angle2 = adjustAngle(targetAngle);
        if (angle1 > angle2)
        {
            if (angle1 - angle2 > 180)
            {
                return true;
            }
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

    bool RoundAngle()
    {
        float angle1 = adjustAngle(entity.transform.rotation.eulerAngles.y+180f);
        float angle2 = adjustAngle(targetAngle);
        if (Mathf.Abs(angle1-angle2)<angleDifferenceAllowed)
        {
            return true;
        }
        return false;
    }

    public void pointTowardsTarget(){
        if(RoundAngle()){
            entity.transform.GetComponent<Rigidbody>().AddRelativeTorque(Vector3.zero);
        }
        else if(goClockwise()){
            entity.transform.GetComponent<Rigidbody>().AddRelativeTorque(new Vector3(0,torque*Time.deltaTime,0));
            //entity.transform.Rotate(new Vector3(0, torque * Time.deltaTime, 0));
        }
        else{
            entity.transform.GetComponent<Rigidbody>().AddRelativeTorque(new Vector3(0, -torque*Time.deltaTime, 0));
            //entity.transform.Rotate(new Vector3(0, -torque * Time.deltaTime, 0));
        }

    }
	
}
