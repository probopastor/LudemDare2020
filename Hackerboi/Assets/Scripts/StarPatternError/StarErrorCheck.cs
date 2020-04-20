using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarErrorCheck : MonoBehaviour
{
    public char[] order = new char[8];

    public int pos = 0;

    private int check;

    public CompleteProgramError cpe;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            order = GetComponent<StarError>().result.ToCharArray();
        }
    }

    public void ButtonCheck(int num)
    {
        check = num;

        //Debug.Log("here" + order[pos]);
        if(order[pos].ToString().Equals(num.ToString()))
        {
            pos++;
            StartCoroutine("ChangeColorGood");
            FindObjectOfType<Path>().DrawLine();

            if (pos == 8)
            {
                //turn off error
                Debug.Log("finsihed correct");
                cpe.SolveProblem();
            }
        }

        else
        {
            Debug.Log("incorrect");
            StartCoroutine("ChangeColorBad");
        }
    }

    IEnumerator ChangeColorGood()
    {
        GetComponent<StarError>().buttons[check - 1].GetComponent<Image>().color = Color.green;
        yield return new WaitForSeconds(.25f);
        GetComponent<StarError>().buttons[check - 1].GetComponent<Image>().color = Color.white;
    }

    IEnumerator ChangeColorBad()
    {
        GetComponent<StarError>().buttons[check - 1].GetComponent<Image>().color = Color.red;
        yield return new WaitForSeconds(.25f);
        GetComponent<StarError>().buttons[check - 1].GetComponent<Image>().color = Color.white;
    }
}
