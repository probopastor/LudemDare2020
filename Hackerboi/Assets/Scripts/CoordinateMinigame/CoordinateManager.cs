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
            temp.Add(CoordinatePanel.GetComponent<ButtonStore>().children[i]);
        }

        //CreateErrorString();
    }

    // Update is called once per frame
    void Update()
    {
     if(Input.GetKeyDown(KeyCode.V))
        {
            CreateErrorString();
        }
    }

    public void UpdateTemp()
    {
        for(int i = 0; i < 9; i++)
        {
            temp.Add(CoordinatePanel.GetComponent<ButtonStore>().children[i]);
        }
    }

    public string CreateErrorString()
    {
        int rand = Random.Range(0, 2);
        int amount = Random.Range(2, buttons.Count - 3);
        UpdateTemp();

        int index;
        if (rand == 0) //letter num letter num
        {
            for (int k = 0; k < amount; k++)
            {
                index = Random.Range(0, temp.Count);

                result += temp[index].GetComponent<CoordinateButtonBehaviour>().coorLet;
                result += temp[index].GetComponent<CoordinateButtonBehaviour>().coorNum;
                //buttons[int.Parse(temp[index].name) - 1].GetComponent<CoordinateButtonBehaviour>().isNeeded = true;
                temp[index].GetComponent<CoordinateButtonBehaviour>().isNeeded = true;

                temp.RemoveAt(index);
            } 
        }

        if(rand == 1) //letter letter num num
        {
            string letter = "";
            string number = "";

            for (int k = 0; k < amount; k++)
            {
                index = Random.Range(0, temp.Count);

                letter += temp[index].GetComponent<CoordinateButtonBehaviour>().coorLet;
                number += temp[index].GetComponent<CoordinateButtonBehaviour>().coorNum;
                //buttons[(int.Parse(temp[index].name)) - 1].GetComponent<CoordinateButtonBehaviour>().isNeeded = true;
                temp[index].GetComponent<CoordinateButtonBehaviour>().isNeeded = true;

                temp.RemoveAt(index);
            }

            result += letter + number;
        }

        Debug.Log(result);
        return result;
    }
}
