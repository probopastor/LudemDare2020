using UnityEngine;
using UnityEngine.UI;

public class LightController : MonoBehaviour
{
    public Image[] lights;

    public static LightController instance;

    private Animator[] animators = new Animator[4];

    private bool isOn;
    private bool gameStarted;

    //Lights 0, 1, 2

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        isOn = false;
        gameStarted = false;

        //Add animator components of lights[] to animators[]
        for (int i = 0; i != lights.Length; i++)
        {
            animators[i] = lights[i].gameObject.GetComponent<Animator>();
        }

        //Sets initial state of lights to be Off
        foreach (Animator anim in animators)
        {
            if (!isOn) anim.SetBool("Off", true);
            else anim.SetBool("Off", false);
        }
    }

    private void Update()
    {
        //If all three router lines are lost, the router is turned off
        if(LineLost(0) && LineLost(1) && LineLost(2))
        {
            isOn = false;
        }
    }
    /// <summary>
    /// Returns how many router lines are lost
    /// </summary>
    /// <returns></returns>
    public int GetLives()
    {
        int i = 0;
        foreach(Animator anim in animators)
        {
            if (anim.GetBool("Lost") == true) i++;
        }

        return i;
    }

    /// <summary>
    /// Sets router line to comprimised animation state
    /// </summary>
    /// <param name="compromisedLine"></param>
    public void Compromise(int compromisedLine)
    {
        animators[compromisedLine].SetBool("Compromised", true);
        animators[3].SetBool("Compromised", true);
    }

    /// <summary>
    /// Sets router line to lost animation state
    /// </summary>
    /// <param name="lostLine"></param>
    public void Lose(int lostLine)
    {
        animators[lostLine].SetBool("Lost", true);
        
        foreach(Animator anim in animators)
        {
            if (anim.GetBool("Lost") == false) return;
        }

        animators[3].SetBool("Lost", true);
        Invoke("ResetLight", 2);
    }

    /// <summary>
    /// Determines the next router line that is not set to lost, and sets it to lost
    /// </summary>
    public void Lose()
    {
        for (int i = 0; i != animators.Length; i++)
        {
            if (i == 3) return;
            if (animators[i].GetBool("Lost") == false)
            {
                Lose(i);
                return;
            }
        }
    }

    /// <summary>
    /// Resets the lose state of all router lines
    /// </summary>
    void ResetLight()
    {
        animators[3].SetBool("Lost", false);
    }

    /// <summary>
    /// Toggles the router between its on and off state
    /// </summary>
    public void PowerToggle()
    {
        //If the router is on, turn it off. If it is off, turn it on.
        if(!isOn)
        {
            isOn = true;
        }
        else if(isOn)
        {
            isOn = false;
        }

        //If a router line is comprimised when the router is shut off, line is no longer comprimised
        foreach (Animator anim in animators)
        {
            anim.SetBool("Compromised", false);

            if (!isOn) anim.SetBool("Off", true);
            else anim.SetBool("Off", false);
        }

        //Sets gameStarted to true the first time you turn on the router
        if(!gameStarted)
        {
            gameStarted = true;
        }
    }

    /// <summary>
    /// Returns true if the router is on, false if the router is off
    /// </summary>
    /// <returns></returns>
    public bool GetRouterStatus()
    {
        return isOn;
    }

    /// <summary>
    /// Pass in a router line to determine if it is lost or not. 
    /// Returns true if lost, false if alive.
    /// </summary>
    /// <param name="line"></param>
    /// <returns></returns>
    public bool LineLost(int line)
    {
        return animators[line].GetBool("Lost");
    }

    /// <summary>
    /// Returns false if the router has not been turned on for the first time.
    /// </summary>
    /// <returns></returns>
    public bool GetGameStarted()
    {
        return gameStarted;
    }
}
