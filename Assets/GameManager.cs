using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   //This script is reponsible for other inputs that don't involve core gameplay

    // Update is called once per frame
    void Update()
    {
        //if the player presses the R then the scene will reload
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0); 
        }
        //if player presses Esc then application will close
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
