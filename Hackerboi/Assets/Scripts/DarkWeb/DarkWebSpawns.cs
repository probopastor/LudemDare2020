using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkWebSpawns : MonoBehaviour
{
    public GameObject[] attacks;
    public GameObject[] helps;

    public GameObject target;

    public GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SpawnNew();
        }
    }

    public void SpawnNew()
    {
        GameObject icon;
        if (Random.Range(0,2) == 0)
        {
            icon = attacks[Random.Range(0, attacks.Length)];
        } else
        {
            icon = helps[Random.Range(0, helps.Length)];
        }

        Instantiate(icon, target.transform.position, Quaternion.identity, canvas.transform);

        Vector3 newPos = new Vector3(Random.Range(0, 1920), Random.Range(0, 1080), 0);

        target.transform.position = newPos;
    }
}
