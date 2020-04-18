using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarErrorCheck : MonoBehaviour
{
    public char[] order = new char[8];

    public int pos = 0;

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
        Debug.Log("here" + order[pos]);
        if(order[pos].ToString().Equals(num.ToString()))
        {
            pos++;

            FindObjectOfType<Path>().DrawLine();

            if(pos == 8)
            {
                //turn off error
                Debug.Log("finsihed correct");
            }
        }

        else
        {
            Debug.Log("incorrect");
        }
    }
}
