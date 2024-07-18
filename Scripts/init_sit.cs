using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class init_sit : MonoBehaviour
{

    [SerializeField] private string[] DrRizzText;
    private Creature[] starters = { Creature.Aurasaurus, Creature.Deviousussy , Creature.Anky };
    private Text Text;
    private int currentText = 0;

    private void Start()
    {
        Text = GameObject.Find("Text").GetComponent<Text>();
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
            foreach (Creature rizkamon in starters)
            {
                GameObject.Find(rizkamon.Name).GetComponent<Image>().enabled = true;
                GameObject.Find(rizkamon.Name).GetComponent<Button>().enabled = true;
            }
        }
    }

    public void sendToNextText()
    {
        currentText += 1;
    }

    public void ChooseDeviousussy()
    {
        Collector.have_rizkamons.Add(Creature.Deviousussy);
        Collector.currentRizkamon = Creature.Deviousussy;
        leave();
    }

    public void ChooseAurasaurus()
    {
        Collector.have_rizkamons.Add(Creature.Aurasaurus);
        Collector.currentRizkamon = Creature.Aurasaurus;
        leave();
    }

    public void ChooseAnky()
    {
        Collector.have_rizkamons.Add(Creature.Anky);
        Collector.currentRizkamon = Creature.Anky;
        leave();
    }

    private void leave()
    {
        SceneManager.LoadScene(2);
    }
}
