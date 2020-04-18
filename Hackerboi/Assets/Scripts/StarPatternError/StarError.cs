using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarError : MonoBehaviour
{
    public List<GameObject> buttons = new List<GameObject>();
    private List<GameObject> temp = new List<GameObject>();

    public float timeToComplete = 15;

    string result = "";

    // Start is called before the first frame update
    void Start()
    {
        string s = GenerateErrorNum();
        Debug.Log(s);
    }

    // Update is called once per frame
    void Update()
    {
        timeToComplete -= Time.deltaTime;

        if (timeToComplete <= 0)
        {
            //penalty
            Debug.Log("did not finish in time");
        }
    }

    public string GenerateErrorNum()
    {
        result = "";
        int index = 0;
        temp = buttons;
        int count = temp.Count;

        for (int i = 0; i < count; i++)
        {
            index = Random.Range(0, temp.Count);

            result += temp[index].name;

            temp.RemoveAt(index);
        }

        return result;
    }
}
