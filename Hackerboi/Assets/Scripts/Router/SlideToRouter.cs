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

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!sliding) sliding = true;
    }

    private void OnEnable()
    {
        myOffset = 0;
    }

    private void Update()
    {
        if (sliding)
        {
            otherArrow.SetActive(false);
            myOffset += slideSpeed;
            computer.transform.Translate(new Vector3(slideSpeed, 0, 0));
            router.transform.Translate(new Vector3(slideSpeed, 0, 0));

            if (Mathf.Abs(myOffset) >= slideDistance)
            {
                sliding = false;
                gameObject.SetActive(false);
                otherArrow.SetActive(true);
            }
        } 
    }
}
