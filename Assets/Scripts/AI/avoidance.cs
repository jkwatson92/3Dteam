using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//description: checks to see if there is a nearby object to avoid
public class avoidance {

    public bool objectInWay(GameObject self)
    {
        if (self.transform.Find("avoidTarget")!= null){
            return true;
        }
        return false;
    }

    public void avoid(GameObject self,float torque)
    {
        self.transform.GetComponent<Rigidbody>().AddRelativeTorque(new Vector3(0, torque*Time.deltaTime, 0));
    }
}
