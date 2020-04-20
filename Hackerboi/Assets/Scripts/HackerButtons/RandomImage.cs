using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomImage : MonoBehaviour
{
    public Sprite[] sprites;

    private void OnEnable()
    {
        GetComponent<Image>().sprite = sprites[Random.Range(0, sprites.Length)];
    }
}
