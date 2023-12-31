using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FlashLight : MonoBehaviour
{
    public Light lighting;
    public TMP_Text text;
    public TMP_Text batteryText;

    private Color barColor = Color.green;
    public float lifetime = 100;
    public float batteries = 0;
    public AudioSource flashON;
    public AudioSource flashOFF;
    public bool on;
    //public bool off;
    void Start()
    {
        lighting = GetComponent<Light>();

        on = false;
        lighting.enabled = false;

    }
    void Update()
    {
        text.text = lifetime.ToString("0") + "%";
        batteryText.text = batteries.ToString();

        if (Input.GetButtonDown("flashlight") && !on)
        {
            flashON.Play();
            lighting.enabled = true;
            on = true;
            //off = false;
        }

        else if (Input.GetButtonDown("flashlight") && on)
        {
            flashOFF.Play();
            lighting.enabled = false;
            on = false;
            //off = true;
        }

        if (on)
        {
            lifetime -= 2 * Time.deltaTime;
        }

        if (lifetime <= 0)
        {
            lighting.enabled = false;
            on = false;
            //off = true;
            lifetime = 0;
        }

        if (lifetime == 0)
        {
            barColor = Color.green;
        }

        if (lifetime >= 100)
        {
            lifetime = 100;
        }


        if (lifetime >= 50f)
        {
            barColor.r = 2 - (2 * lifetime) / 100;
        }
        else if (lifetime > 0)
        {
            barColor.g = 2 * lifetime / 100;
        }

        if (Input.GetButtonDown("reload") && batteries >= 1)
        {
            batteries -= 1;
            lifetime += 50;
        }

        if (Input.GetButtonDown("reload") && batteries == 0)
        {
            return;
        }

        if (batteries <= 0)
        {
            batteries = 0;
        }
    }
}