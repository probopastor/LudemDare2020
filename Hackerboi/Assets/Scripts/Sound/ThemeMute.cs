using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeMute : MonoBehaviour
{

    private AudioSource themeAudio;

    // Start is called before the first frame update
    void Start()
    {
        themeAudio = GetComponent<AudioSource>();
        StartCoroutine(waitVolume());
    }

    private IEnumerator waitVolume()
    {
        yield return new WaitForSeconds(10.3f);
        themeAudio.volume = 0.25f;
    }
}
