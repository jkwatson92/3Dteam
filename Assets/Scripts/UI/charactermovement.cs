using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//description: USES physics engine to move character
//IMPORTANT: If not using a circular collider: will need to change rotation code
public class charactermovement : MonoBehaviour {

    public float force;
    public input userInput;
    public float rotationRate;
    public float maxVelocity;
    public float sprintVelocity;
    int journalCount=0;

    public AudioClip doorEffect;
    public AudioSource effectSource;

    // Use this for initialization
    void Start()
    {
        userInput = new input();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Door"))
        {
            Debug.Log("Player collided");
            effectSource.clip = doorEffect;
            effectSource.Play();
            other.gameObject.SetActive(false);
        } else if (other.gameObject.CompareTag("Book"))
        {
            Debug.Log("Player collided");
            effectSource.clip = doorEffect;
            effectSource.Play();
            other.gameObject.SetActive(false);
            journalCount += 1;
            //load end scene win after collection of all journals
            if (journalCount == 1)
            {
                SceneManager.LoadScene(3, LoadSceneMode.Single);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        userInput.update();
        float factor = force * Time.deltaTime;
        if (transform.GetComponent<Rigidbody>().velocity.magnitude < maxVelocity)
        {
            transform.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(userInput.horizontal.weight * factor, 0, userInput.vertical.weight * factor));
        }
        else if (transform.GetComponent<Rigidbody>().velocity.magnitude < sprintVelocity){
            if(userInput.shift.weight != 0){
                transform.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(userInput.horizontal.weight * factor, 0, userInput.vertical.weight * factor));
            }
        }
        if (userInput.horizontal.weight == 0 && userInput.vertical.weight == 0){
            if (transform.GetComponent<Rigidbody>().velocity.magnitude >0){
                transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }
        factor = rotationRate * Time.deltaTime;
        transform.Rotate(0, userInput.mousex.weight * factor, 0);
        if (Mathf.Abs(transform.GetChild(0).rotation.eulerAngles.x - (userInput.mousey.weight * factor)) <70 || Mathf.Abs(transform.GetChild(0).rotation.eulerAngles.x - (userInput.mousey.weight * factor))>290)
        {
            transform.GetChild(0).Rotate(-userInput.mousey.weight * factor, 0, 0);
        }

    }
}
