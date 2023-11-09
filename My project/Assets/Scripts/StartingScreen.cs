﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingScreen : MonoBehaviour
{
    private GameObject player;
    public GameObject startingScreen;

    public float waitTime;


    void Start()
    {
        startingScreen.SetActive(true);
        player = GameObject.FindWithTag("Player");
        player.GetComponent<PlayerMotor>().enabled = false;
        player.GetComponent<PlayerLook>().enabled = false;
        player.GetComponent<InputManager>().enabled = false;

        StartCoroutine(Starting());
    }

    IEnumerator Starting()
    {
        yield return new WaitForSeconds(waitTime);
        startingScreen.SetActive(false);
        player.GetComponent<PlayerMotor>().enabled = true;
        player.GetComponent<PlayerLook>().enabled = true;
        player.GetComponent<InputManager>().enabled = true;

    }




    void Update()
    {
        
    }
}
