using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour {

	public int health;
	public int numHearts;
	public Image[] hearts;
	public Sprite fullHeart;
	public Sprite emptyHeart;

	// Use this for initialization
	void Start () {
		health = 3;
	}
	
	// Update is called once per frame
	void Update () {
		if (health > numHearts) 
		{
			health = numHearts;
		}

		if (health == 0) {
			SceneManager.LoadScene("EndScene", LoadSceneMode.Single); //if player dies go to try again screen
		}

		for (int i = 0; i < hearts.Length; i++) 
		{
			if (i < health) 
			{
				hearts[i].sprite = fullHeart;
			}
			else {
				hearts[i].sprite = emptyHeart;
			}
			if (i < numHearts) 
			{
				hearts[i].enabled = true;
			}
			else {
				hearts[i].enabled = false;
			}
		}
	}
}
