using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public List<Transform> points = new List<Transform>();
    private LineRenderer lr;

    private int count;

    // Start is called before the first frame update
    void Start()
    {
        count = FindObjectOfType<StarErrorCheck>().pos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPointArray()
    {
        for(int i = 0; i < 8; i++)
        {
            points.Add(FindObjectOfType<Path>().transform.GetChild(FindObjectOfType<StarErrorCheck>().order[i]).transform);
        }
    }

    public void DrawLine()
    {
        GameObject lineObject = new GameObject();
        this.lr = lineObject.AddComponent<LineRenderer>();
        this.lr.startWidth = 3f;
        this.lr.endWidth = .1f;
        this.lr.positionCount = points.Count;

        Vector3[] pointArray = new Vector3[count];
        for(int i = 0; i < count; i++)
        {
            Vector3 pointPos = this.points[i].position;
            pointArray[i] = new Vector3(pointPos.x, pointPos.y, 0f);
        }

        this.lr.SetPositions(pointArray);
    }
}
