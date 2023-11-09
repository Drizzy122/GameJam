using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator door;
   
    public GameObject openText;
    public GameObject closeText;

    public AudioSource openSound;
    public AudioSource closeSound;

    private bool inReach;
    private bool doorisOpen;
    private bool doorisClosed;

    void Start()
    {
        inReach = false;
        doorisClosed = true;
        doorisOpen = false;
        closeText.SetActive(false);
        openText.SetActive(false);
    }
    void Update()
    {
        if (inReach && doorisClosed && Input.GetButtonDown("Interact"))
        {
            door.SetBool("Open", true);
            door.SetBool("Closed", false);
            openText.SetActive(false);
            openSound.Play();
            doorisOpen = true;
            doorisClosed = false;
        }
        else if (inReach && doorisOpen && Input.GetButtonDown("Interact"))
        {
            door.SetBool("Open", false);
            door.SetBool("Closed", true);
            closeText.SetActive(false);
            closeSound.Play();
            doorisClosed = true;
            doorisOpen = false;
        }
        if (inReach && Input.GetButtonDown("Interact"))
        {
            openText.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach" && doorisClosed)
        {
            inReach = true;
            openText.SetActive(true);
        }

        if (other.gameObject.tag == "Reach" && doorisOpen)
        {
            inReach = true;
            closeText.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            openText.SetActive(false);
          
        }
    }
}