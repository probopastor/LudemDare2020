using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HackerTimeController : MonoBehaviour
{
    public RectTransform slider;

    public float range;

    public float moneyZone;

    public float speed;

    private float offset;

    private bool movingRight;
    private HackTimeManager hackTimeManager;

    private AudioSource barSource;
    public AudioClip pass, fail;

    // Start is called before the first frame update
    void Start()
    {
        hackTimeManager = FindObjectOfType<HackTimeManager>();
        offset = -range;
        barSource = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (movingRight)
        {
            offset += speed;
            slider.position += Vector3.right * speed;

            if (offset > range) movingRight = false;

        } else
        {
            offset -= speed;
            slider.position -= Vector3.right * speed;

            if (offset < -range) movingRight = true;
        }
    }

    public void Activate()
    {
        Debug.Log(offset);
        if (offset >= -56 && offset <= 32)
        {
            barSource.PlayOneShot(pass, 0.25f);
        } else
        {
            LightController.instance.Lose();
            barSource.PlayOneShot(fail, 0.25f);
        }
        hackTimeManager.SolveProblem();
        Destroy(gameObject);
        
    }
}
