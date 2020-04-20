using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Dragable : EventTrigger
{
    private bool dragging;
    public Vector2 xBounds;
    public Vector2 yBounds;
    private Image img;
    private Color highlight;

    private void Start()
    {
        if (GetComponent<Image>() != null)
            img = GetComponent<Image>();
        xBounds = new Vector2(300, 1400);
        yBounds = new Vector2(100, 980);

        highlight = Color.cyan;
    }

    public void Update()
    {
        if (dragging)
        {
            img.color = highlight;
            if (Input.mousePosition.x < xBounds.y && Input.mousePosition.x > xBounds.x &&
                Input.mousePosition.y < yBounds.y && Input.mousePosition.y > yBounds.x)
                transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            else dragging = false;
        } else
        {
            img.color = Color.white;
        }
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        dragging = true;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        dragging = false;
    }
}