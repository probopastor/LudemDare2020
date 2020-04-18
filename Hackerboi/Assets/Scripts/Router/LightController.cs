using UnityEngine;
using UnityEngine.UI;

public class LightController : MonoBehaviour
{
    public Image[] lights;

    public static LightController instance;

    private Animator[] animators = new Animator[4];

    private bool isOn;

    //Lights 0, 1, 2

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        isOn = true;

        for (int i = 0; i != lights.Length; i++)
        {
            animators[i] = lights[i].gameObject.GetComponent<Animator>();
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
            }
        }
    }

    void ResetLight()
    {
        animators[3].SetBool("Lost", false);
    }

    public void PowerToggle()
    {
        isOn = !isOn;

        foreach (Animator anim in animators)
        {
            anim.SetBool("Compromised", false);

            if (!isOn) anim.SetBool("Off", true);
            else anim.SetBool("Off", false);
        }
    }
}
