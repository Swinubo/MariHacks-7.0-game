using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coinCount : MonoBehaviour
{

    public static float coinAmount=100;
    private Text coinAmountDispl;
    private Text peasantAmountDispl;
    private Text goonAmountDispl;
    private Text mafiaBossAmountDispl;

    // Start is called before the first frame update
    void Start()
    {
        coinAmountDispl = GetComponent<Text>();
        peasantAmountDispl = GameObject.Find("Peasant amount").GetComponent<Text>();
        goonAmountDispl = GameObject.Find("Goon amount").GetComponent<Text>();
        mafiaBossAmountDispl = GameObject.Find("Mafia Boss amount").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        coinAmountDispl.text = coinAmount.ToString();

        peasantAmountDispl.text = "x" + Balls.peasantCount.ToString();
        goonAmountDispl.text ="x" +Balls.goonCount.ToString();
        mafiaBossAmountDispl.text = "x" +Balls.mafiaBossCount.ToString();
    }

}
