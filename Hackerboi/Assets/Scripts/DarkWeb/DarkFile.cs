using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkFile : MonoBehaviour
{

    public GameObject message;

    public void OpenThing()
    {
        message.SetActive(true);
    }

    public void KillSelf()
    {
        Destroy(gameObject);
    }
}
