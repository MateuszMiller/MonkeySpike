using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public Movement player;
    public GameObject pause;
    private void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){
            StartGame();
        }
    }
public void StartGame(){
    pause.SetActive(false);
    player.enabled = true;
    Destroy(this);
}
}
