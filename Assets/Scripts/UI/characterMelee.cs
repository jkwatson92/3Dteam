﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMelee : MonoBehaviour {

	public Camera cam;
	public GameObject myWep;
	Animator weaponAnim;
	public int weaponDamage;
	public int weaponRange;
	void Start () {
		weaponAnim = myWep.GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
		{
			DoAttack();
		}
	}

	private void DoAttack()
	{
		Ray ray = cam.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, weaponRange))
		{
			if(hit.collider.tag == "Enemy")
			{
				//EnemyHealth eHealth = hit.collider.GetComponent<EnemyHealth>();
				//eHealth.TakeDamage(weaponDamage);
			}
		}
	}
}
