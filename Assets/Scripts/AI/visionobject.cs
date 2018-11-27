using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Description: Handles detection and seeking of target
//IMPORTANT: In order for enemies to be found, must attach this to a game object with collider attached to serve as visual field, as well as an empty game object
public class visionobject : MonoBehaviour {
    float lifespan;
    public float maxSeekTime;
    public float maxSearchTime;
    public float velocity;
    bool found;
    float searchTimer;
    float xconstant;
    float yconstant;
    void Start()
    {
        found = false;
        if (transform.name == "seek"){
            lifespan = 0;
        }
    }

    private void Update()
    {
        if (transform.name == "found"){
            if (found == false){
                searchTimer = 0;
            }
            found = true;
            if (searchTimer>maxSeekTime){
                found = false;
                transform.name = "vision";
            }
            searchTimer += Time.deltaTime;
        }

        if(transform.name == "seek"){
            lifespan += Time.deltaTime;
            if (lifespan>maxSeekTime){
                Destroy(gameObject);
            }
            float factor = velocity * Time.deltaTime;
            transform.GetChild(0).localPosition += new Vector3(0,0,factor/transform.GetChild(0).lossyScale.z);
            transform.position = transform.GetChild(0).position;
            transform.GetChild(0).localPosition = Vector3.zero;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (gameObject.name != "seek")
        {
            if (other.name == "UserCollider")
            {
                if(transform.childCount>10){
                    return;
                }
                GameObject seek = Instantiate(gameObject);
                for (int i = 0; i < seek.transform.childCount; i++){
                    if (seek.transform.GetChild(i).name == "seek"){
                        Destroy(seek.transform.GetChild(i).gameObject);
                    }
                }
                seek.name = "seek";
                seek.transform.SetParent(transform);
                seek.transform.localScale = new Vector3(.1f, 1, .05f);
                seek.transform.position = transform.position;
                float xdistance = -(other.transform.position.x - transform.position.x);
                float zdistance = other.transform.position.z - transform.position.z;
                float targetAngle = Mathf.Atan2(zdistance, xdistance) * Mathf.Rad2Deg;
                targetAngle -= 90;
                seek.transform.Rotate(0, targetAngle- transform.rotation.y, 0);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent != transform.parent.parent)
        {
            if (gameObject.name == "seek"){
                if (other.name == "UserCollider"){
                    transform.parent.name = "found";
                }
                Destroy(gameObject);
            }
        }
    }
}
