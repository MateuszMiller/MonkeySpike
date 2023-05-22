using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public Movement player;
    public GameObject pause;
    public GameObject playerObject;

    private void Start()
    {
        playerObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            StartGame();
        }
    }
    public void StartGame()
    {
        pause.SetActive(false);
        player.enabled = true;
        player.Jump();
        Destroy(this);
    }
}
