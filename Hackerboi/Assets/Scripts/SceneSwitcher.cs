using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public static void GoTo(int scene)
    {
        SceneManager.LoadSceneAsync(scene, LoadSceneMode.Single);
    }
}
