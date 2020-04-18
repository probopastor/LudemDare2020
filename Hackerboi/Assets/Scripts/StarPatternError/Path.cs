using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public List<Transform> points = new List<Transform>();
    private LineRenderer lr;

    private int count;

    private GameObject par;

    public Material m;

    // Start is called before the first frame update
    void Start()
    {
        count = FindObjectOfType<StarErrorCheck>().pos;
        par = FindObjectOfType<Path>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPointArray()
    {
        par = FindObjectOfType<Path>().gameObject;


        for(int i = 0; i <= 7; i++)
        {
            points.Add(par.transform.GetChild(FindObjectOfType<StarError>().nums[i] - 1).transform);
        }
    }

    public void DrawLine()
    {
        if (FindObjectOfType<LineRenderer>())
        {
            GameObject line = FindObjectOfType<LineRenderer>().gameObject;
            Destroy(line);
        }

        count = FindObjectOfType<StarErrorCheck>().pos;

        GameObject lineObject = new GameObject();
        this.lr = lineObject.AddComponent<LineRenderer>();
        this.lr.startWidth = .1f;
        this.lr.endWidth = .1f;
        this.lr.positionCount = count;
        this.lr.material = m;
        this.lr.startColor = Color.white;
        this.lr.endColor = Color.white;

        Vector3[] pointArray = new Vector3[count];
        for (int i = 0; i < count; i++)
        {
            Vector3 pointPos = this.points[i].position;
            pointArray[i] = new Vector3(pointPos.x, pointPos.y, 0f);
        }

        this.lr.SetPositions(pointArray);
    }
}
