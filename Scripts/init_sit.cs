using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class init_sit : MonoBehaviour
{

    [SerializeField] private string[] DrRizzText;
    private Creature[] starters;
    private Text Text;
    private int currentText = 0;

    private void Start()
    {
        Text = GameObject.Find("Text").GetComponent<Text>();
        starters = new Creature[] { Creature.Aurasaurus, Creature.Deviousussy , Creature.Anky };
    }

    private void Update()
    {
        if (currentText != 8)
        {
            Text.text = DrRizzText[currentText];
            Debug.Log(currentText);
        }
        else
        {
            foreach (rizkamon in starters)
            {
                GameObject.Find(rizkamon.Name).GetComponent<Image>().enabled = true;
                GameObject.Find(rizkamon.Name).GetComponent<Button>().enabled = true;
                GameObject.Find(rizkamon.Name + "_text").GetComponent<Text>().enabled = true;
            }
        }
    }

    public void sendToNextText()
    {
        currentText += 1;
    }

    public void ChooseDeviousussy()
    {
        ChooseRizkamon(Creature.Deviousussy);
    }

    public void ChooseAurasaurus()
    {
        ChooseRizkamon(Creature.Aurasaurus);
    }

    public void ChooseAnky()
    {
        ChooseRizkamon(Creature.Anky);
    }

    private void ChooseRizkamon(Creature rizkamon)
    {
        Collector.have_rizkamons.Add(rizkamon);
        Collector.currentRizkamon = rizkamon;
        leave();
    }

    private void leave()
    {
        SceneManager.LoadScene(3);
    }
}
