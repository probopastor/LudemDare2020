using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmailGenerator : MonoBehaviour
{
    public List<string> goodSubjects = new List<string>();
    public List<string> badSubjects = new List<string>();
    public List<string> goodDateTime = new List<string>();
    public List<string> badDateTime = new List<string>();

    public GameObject emailPrefab;
    public GameObject emailPanel;

    public void GenerateGoodEmails()
    {
        int randSubject = Random.Range(0, goodSubjects.Count);
        int randDateTime = Random.Range(0, goodDateTime.Count);

        GameObject g = Instantiate(emailPrefab, emailPanel.transform);
        g.GetComponent<Email>().SetVars(goodSubjects[randSubject], goodDateTime[randDateTime], false);
    }

    public void GenerateBadEmails()
    {
        int randSubject = Random.Range(0, badSubjects.Count);
        int randDateTime = Random.Range(0, badDateTime.Count);

        GameObject g = Instantiate(emailPrefab, emailPanel.transform);
        g.GetComponent<Email>().SetVars(badSubjects[randSubject], badDateTime[randDateTime], true);
    }
}
