using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckCoordinate : MonoBehaviour
{
    private CoordinateManager manager;

    public bool isDone = false;

    public CompleteProgramError cpe;

    public void Start()
    {
        manager = gameObject.GetComponent<CoordinateManager>();
    }
    public void AreaClicked(GameObject g)
    {
        if (g.GetComponent<CoordinateButtonBehaviour>().isPressed == false)
        {
            g.GetComponent<CoordinateButtonBehaviour>().isPressed = true;

            g.GetComponent<Image>().color = Color.white;
        }

        else if (g.GetComponent<CoordinateButtonBehaviour>().isPressed == true)
        {
            g.GetComponent<CoordinateButtonBehaviour>().isPressed = false;

            g.GetComponent<Image>().color = new Color(.18f, .18f, .18f, 1);
        }

        isDone = AllCorrect();

        if(isDone == true)
        {
            Debug.Log("correctCoor");
            //fix error
            cpe.SolveProblem();
        }
    }

    public bool AllCorrect()
    {
        bool isCorrect = false;
        int count = 0;

        for(int i = 0; i < gameObject.GetComponent<CoordinateManager>().buttons.Count; i++)
        {
            if ((manager.buttons[i].gameObject.GetComponent<CoordinateButtonBehaviour>().isNeeded == true && manager.buttons[i].gameObject.GetComponent<CoordinateButtonBehaviour>().isPressed == true) 
                || (manager.buttons[i].gameObject.GetComponent<CoordinateButtonBehaviour>().isNeeded == false && manager.buttons[i].gameObject.GetComponent<CoordinateButtonBehaviour>().isPressed == false))
            {
                count++;
            }

            if(count == 9)
            {
                isCorrect = true;
            }

            //Debug.Log(isCorrect);
        }

        return isCorrect;
    }
}
