using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HackerTimeController : MonoBehaviour
{
    public RectTransform slider;

    public int range;

    public int moneyZone;

    public int speed;

    private int offset;

    private bool movingRight;

    // Start is called before the first frame update
    void Start()
    {
        offset = -range;
    }

    // Update is called once per frame
    void Update()
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
        if (offset > -moneyZone && offset < moneyZone)
        {
            
        } else
        {
            LightController.instance.Lose();
        }

        EventManager.instance.SetErrorStatus(true);
    }
}
