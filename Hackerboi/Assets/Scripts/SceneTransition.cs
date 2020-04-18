using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    private ParticleSystem ps;
    private bool ramping;
    public GameObject ss;

    public GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        Invoke("Ramp", 2);
    }

    void Ramp()
    {
        ramping = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (ramping)
        {
            var emission = ps.emission;
            emission.rateOverTime = emission.rateOverTime.constant + 1f;
        }

        if (ss.transform.localScale.x >= 1.05f)
        {
            ss.SetActive(false);
            canvas.SetActive(true);
            Destroy(gameObject, 2);
        }
        
    }

    private void FixedUpdate()
    {
        ss.transform.localScale += new Vector3(0.002f, 0.002f, 0);
    }
}
