using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatingItem : MonoBehaviour {
    public float floatSpeed;
    private Vector3 startPosition;
    private bool isUp;
   

    void Start()
    {
        startPosition = transform.position;
        isUp = true;
    }

    void Update()
    {
        //float distance = Vector3.Distance(startPosition, transform.position);
        //if (isUp)
        //{
        //    moveUp();
        //}
        //else if (!isUp)
        //{
        //    moveDown();
        //}
        float distance = Vector3.Distance(startPosition, transform.position);
        //Debug.Log("Distance: " + distance);
        if (isUp)
        {
            moveUp();

            if (distance >= 10.0)
            {
                isUp = false;
            }

        }
        //else
        //{
        //    moveDown();

        //    if (transform.position.y <= startPosition.y)
        //    {
        //        isUp = true;

        //    }

        //}

    }

    void moveUp()
    {
        //transform.position.y += floatSpeed * Time.deltaTime;
        transform.Translate(Vector3.up * floatSpeed * Time.deltaTime);
        isUp = false;
    }
    void moveDown()
    {
        //transform.position.y -= floatSpeed * Time.deltaTime;
        transform.Translate(Vector3.down * floatSpeed * Time.deltaTime);
        isUp = true;
    }
}
