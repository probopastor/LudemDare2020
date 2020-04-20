using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour
{
    private AudioSource clickSource;
    public AudioClip[] clicking;

    // Start is called before the first frame update
    void Start()
    {
        clickSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            clickSource.PlayOneShot(clicking[Random.Range(0,clicking.Length)], 1.8F);
    }
}
