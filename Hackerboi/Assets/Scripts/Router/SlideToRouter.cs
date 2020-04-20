using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;


    public class SlideToRouter : MonoBehaviour, IPointerEnterHandler
    {
    public GameObject computer;
    public GameObject router;
    public int slideDistance;
    public float slideSpeed;

    public GameObject otherArrow;

    private float myOffset = 0;

    private bool sliding;

    private AudioSource arrowAudio;
    public AudioClip[] arrowSounds;
    private bool arrowNoise;

    void Start()
    {
        arrowAudio = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
    }

        public void OnPointerEnter(PointerEventData eventData)
    {
        if (!sliding)
        {
            sliding = true;
        }
    }

    private void OnEnable()
    {
        myOffset = 0;
    }

    private void Update()
    {
        if (sliding)
        {
            if (arrowNoise)
            {
                arrowAudio.PlayOneShot(arrowSounds[Random.Range(0, 2)], 0.8F);
                arrowNoise = false;
            } 

            otherArrow.SetActive(false);
            myOffset += slideSpeed;
            computer.transform.Translate(new Vector3(slideSpeed, 0, 0));
            router.transform.Translate(new Vector3(slideSpeed, 0, 0));

            if (Mathf.Abs(myOffset) >= slideDistance)
            {
                sliding = false;
                gameObject.SetActive(false);
                otherArrow.SetActive(true);
                arrowNoise = true;
            }
        } 
    }

    public bool isShifted()
    {
        if(gameObject.activeInHierarchy && !sliding)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
