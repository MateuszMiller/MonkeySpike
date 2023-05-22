using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreen : MonoBehaviour
{
    
public GameObject pauseMenu;
public GameObject deathMenu;


    public void Replay(){
        deathMenu.SetActive(false);
        
        pauseMenu.SetActive(true);

    }
}
