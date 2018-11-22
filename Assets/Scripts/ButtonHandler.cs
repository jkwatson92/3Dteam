using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour {
    public bool isStart;
    public bool isQuit;
    public Text buttonText;
    public AudioClip effect;
    public AudioSource effectSource;

    public void onHover()
    {
        buttonText.color = Color.red;
        effectSource.clip = effect;
        effectSource.Play();
    }

    public void OnMouseExit()
    {
        buttonText.color = Color.black;
    }


    public void OnMouseUp()
    {
        if (isStart)
        {
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }
        if (isQuit)
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }
    }

}
