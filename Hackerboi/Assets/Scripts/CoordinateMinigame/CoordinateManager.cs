using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordinateManager : MonoBehaviour
{
    public List<GameObject> buttons = new List<GameObject>();
    private List<GameObject> temp = new List<GameObject>();
    public string result = "";

    public GameObject CoordinatePanel;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 9; i++)
        {
            //buttons.Add(CoordinatePanel.transform.GetChild(i).gameObject);
            buttons.Add(CoordinatePanel.GetComponent<ButtonStore>().children[i]);
        }

        CreateErrorString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string CreateErrorString()
    {
        int rand = Random.Range(0, 2);
        int amount = Random.Range(0, buttons.Count);
        Debug.Log(amount);

        int index = 0;

        if (rand == 0) //letter num letter num
        {
            for(int i = 0; i < amount; i++)
            {
                temp = buttons;

                for (int k = 0; k < amount; k++)
                {
                    index = Random.Range(0, temp.Count);

                    result += buttons[index].GetComponent<CoordinateButtonBehaviour>().coorLet;
                    result += buttons[index].GetComponent<CoordinateButtonBehaviour>().coorNum;

                    temp.RemoveAt(index);
                } 
            }
        }

        if(rand == 1) //letter letter num num
        {
            string letter = "";
            string number = "";

            for (int i = 0; i < amount; i++)
            {
                temp = buttons;

                for (int k = 0; k < amount; k++)
                {
                    index = Random.Range(0, temp.Count);

                    letter += buttons[index].GetComponent<CoordinateButtonBehaviour>().coorLet;
                    number += buttons[index].GetComponent<CoordinateButtonBehaviour>().coorNum;

                    temp.RemoveAt(index);
                }
            }

            result += letter + number;
        }

        Debug.Log(result);
        return result;
    }
}
