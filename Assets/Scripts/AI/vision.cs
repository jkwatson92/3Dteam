using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Description: Function returns true if the game object has found its target
public class vision {

    public bool userFound(GameObject self){
        if (self.transform.Find("found") != null)
        {
            return true;
        }
        return false;
    }
}
