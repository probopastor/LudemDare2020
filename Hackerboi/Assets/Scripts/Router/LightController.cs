using UnityEngine;
using UnityEngine.UI;

public class LightController : MonoBehaviour
{
    public Image[] lights;

    private Animator[] animators = new Animator[4];

    private bool isOn;

    //Lights 0, 1, 2

    // Start is called before the first frame update
    void Start()
    {
        isOn = true;

        for (int i = 0; i != lights.Length; i++)
        {
            animators[i] = lights[i].gameObject.GetComponent<Animator>();
        }
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
