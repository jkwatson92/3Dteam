using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Doors : MonoBehaviour {

    public AudioClip effect;
    public AudioSource effectSource;
    // Use this for initialization
    void Start()
    {
       

    }

    void onCollisionEnter(Collider other)
    {

            //Debug.Log("Player collided");
            effectSource.clip = effect;
            effectSource.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }



}
