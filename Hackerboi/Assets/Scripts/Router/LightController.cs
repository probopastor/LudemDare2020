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

        for (int i = 0; i != lights.Length; i++)
        {
            animators[i] = lights[i].gameObject.GetComponent<Animator>();
        }

        foreach (Animator anim in animators)
        {
            if (!isOn) anim.SetBool("Off", true);
            else anim.SetBool("Off", false);
        }
    }

    private void Update()
    {
        if(LineLost(0) && LineLost(1) && LineLost(2))
        {
            isOn = false;
        }
    }

    public int GetLives()
    {
        int i = 0;
        foreach(Animator anim in animators)
        {
            if (anim.GetBool("Lost") == true) i++;
        }

        return i;
    }

    public void Compromise(int compromisedLine)
    {
        animators[compromisedLine].SetBool("Compromised", true);
        animators[3].SetBool("Compromised", true);
    }

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

    void ResetLight()
    {
        animators[3].SetBool("Lost", false);
    }

    public void PowerToggle()
    {
        if(!isOn)
        {
            isOn = true;
        }
        else if(isOn)
        {
            isOn = false;
        }

        foreach (Animator anim in animators)
        {
            anim.SetBool("Compromised", false);

            if (!isOn) anim.SetBool("Off", true);
            else anim.SetBool("Off", false);
        }

        if(!gameStarted)
        {
            gameStarted = true;
        }
    }

    public bool GetRouterStatus()
    {
        return isOn;
    }

    public bool LineLost(int line)
    {
        return animators[line].GetBool("Lost");
    }

    public bool GetGameStarted()
    {
        return gameStarted;
    }
}
