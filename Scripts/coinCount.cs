using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coinCount : MonoBehaviour
{

    public static int coinAmount=0;
    private Text coinAmountDispl;


    // Start is called before the first frame update
    void Start()
    {
        coinAmountDispl = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        coinAmountDispl.text = coinAmount.ToString();
    }

}
