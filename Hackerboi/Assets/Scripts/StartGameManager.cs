using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGameManager : MonoBehaviour
{
    public GameObject hackerSlider;
    public bool gameHasStarted = false;

    private IEnumerator coroutine;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (LightController.instance.GetGameStarted() && !gameHasStarted)
        {
            StartCoroutine(FillBar());
        }
    }

    public IEnumerator FillBar()
    {
        gameHasStarted = true;
        hackerSlider.SetActive(true);

        for (int i = 0; i < 8; i++)
        {
            yield return new WaitForSeconds(.6f);
            hackerSlider.GetComponent<Slider>().value++;
           
        }
        
            
            
    }

}
