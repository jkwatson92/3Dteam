using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMelee : MonoBehaviour {

	public Camera cam;
	public GameObject myWep;
	Animator weaponAnim;
	public int weaponDamage;
	public float weaponRange;
	public float weaponCooldown;
	public AudioSource soundSource;
	public AudioClip swing;
	public AudioClip landHit;

	private float cooldownTimer;


	void Start () {
		cooldownTimer = 3;
		weaponAnim = myWep.GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
		cooldownTimer += Time.deltaTime;
		if(Input.GetMouseButtonDown(0) && cooldownTimer >= weaponCooldown)
		{	
			cooldownTimer = 0;
			weaponAnim.SetTrigger("Hit");
			soundSource.clip = swing;
			soundSource.Play();
			DoAttack();
		}
	}

	private void DoAttack()
	{
		Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, weaponRange))
		{
			if(hit.collider.tag == "Enemy")
			{
				soundSource.clip = landHit;
				soundSource.Play();
				//EnemyHealth eHealth = hit.collider.GetComponent<EnemyHealth>();
				//eHealth.TakeDamage(weaponDamage);
			}
		}
	}
}
