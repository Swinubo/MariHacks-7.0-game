using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Collector : MonoBehaviour
{
    private Rigidbody2D rb;

    //general rizkamons
    /*
    public static bool have_bip = false;
    public static bool have_punny = false;
    public static bool have_richard = false;
    public static bool have_joe = false;
    public static bool have_alvin = false;
    public static bool have_whale = false;
    public static bool have_quakor = false;
    public static bool have_bellico = false;
    public static bool have_beeogee = false;
    public static bool have_terroc = false;
    public static bool have_jo = false;

    //gymarite rizkamons
    public static bool have_travis = false;
    public static bool have_ligma = false;*/

    public static List<string> have_rizkamons = new List<string>();

    [SerializeField] private GameObject[] rizkamonsSER;
    public static GameObject[] rizkamons;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rizkamons = rizkamonsSER;
    }

    private void Update()
    {
        /*if (rizkamons.Count == 13)
        {
            StartCoroutine(goToEnd());
        }*/
    }

    private IEnumerator goToEnd()
    {
        rb.bodyType = RigidbodyType2D.Static;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);
    }

}

