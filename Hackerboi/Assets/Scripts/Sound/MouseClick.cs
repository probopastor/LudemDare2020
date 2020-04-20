﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseClick : MonoBehaviour
{
    private AudioSource clickSource;
    public AudioClip[] clicking;
    private GameObject rightArrow;
    private GameObject leftArrow;
    private Scene scene;

    // Start is called before the first frame update
    void Start()
    {
        clickSource = GetComponent<AudioSource>();
        scene = SceneManager.GetActiveScene();
        if (scene.name == "MainGame")
        {
            rightArrow = GameObject.Find("ArrowToRouter");
            leftArrow = GameObject.Find("ArrowToDesktop");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (scene.name == "MainGame")
        {
            if (Input.GetMouseButtonDown(0) && rightArrow.active)
            {
                clickSource.PlayOneShot(clicking[Random.Range(0, clicking.Length)], 1.8F);
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                clickSource.PlayOneShot(clicking[Random.Range(0, clicking.Length)], 1.8F);
            }
        }
    }
}