using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAudio : MonoBehaviour {
    public AudioClip Effect;
    public AudioSource EffectSource;
	// Use this for initialization
	void Start () {
        EffectSource.clip = Effect;
        EffectSource.volume = 0.8f;
	    EffectSource.Play();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
