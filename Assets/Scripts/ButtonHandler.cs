using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour {
    public bool isStart;
    public bool isQuit;
    public Text buttonText;

    public void onHover()
    {
        buttonText.color = Color.red;
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
            Application.Quit();
        }
    }

}
