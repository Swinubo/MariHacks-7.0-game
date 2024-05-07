using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Collector : MonoBehaviour
{
    public static bool have_bip = false;
    public static bool have_blue = false;
    public static bool have_red = false;
    public static bool have_joe = false;

    private void Update()
    {
        Debug.Log("START");
        Debug.Log(have_bip);
        Debug.Log(have_blue);
        Debug.Log(have_red);
        Debug.Log(have_joe);
        if (have_bip && have_blue && have_red && have_joe)
        {
            Debug.Log("BOBOss");
            SceneManager.LoadScene(1);
        }
    }

} //this program just holds the variables for the pokemons

