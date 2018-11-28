using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//description: takes user input - and moves camera based on input using wasd, space for up, and v for down
//doesn't factor in any colliders or physics(like a ghost)
//attach to the parent of the camera (moves both parent and camera)
//DONT RUN if there is any other UI running
public class ghost : MonoBehaviour {

    public float velocity;
    public input userInput;
    public float rotationRate;

    // Use this for initialization
    void Start () {
        userInput = new input();
	}
	
	// Update is called once per frame
	void Update () {
        userInput.update();
        float factor = velocity * Time.deltaTime;
        transform.GetChild(0).localPosition += new Vector3(userInput.horizontal.weight*factor, userInput.jump.weight* factor, userInput.vertical.weight* factor);
        transform.position = transform.GetChild(0).position;
        transform.GetChild(0).localPosition = Vector3.zero;
        factor = rotationRate * Time.deltaTime;
        transform.Rotate(0, userInput.mousex.weight * factor, 0);
        transform.GetChild(0).Rotate(-userInput.mousey.weight * factor, 0, 0);
	}
}
