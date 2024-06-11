using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Collector : MonoBehaviour
{
    private Rigidbody2D rb;

    //general rizkamons
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
    public static bool have_ligma = false;

    [SerializeField] private GameObject[] rizkamonsSER;
    public static GameObject[] rizkamons;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rizkamons = rizkamonsSER;
    }

    private void Update()
    {
        if (have_bip && have_punny && have_richard && have_joe && have_alvin && have_whale && have_travis && have_ligma && have_quakor && have_beeogee && have_bellico && have_terroc && have_jo)
        {
            StartCoroutine(goToEnd());
        }
    }

    private IEnumerator goToEnd()
    {
        rb.bodyType = RigidbodyType2D.Static;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);
    }

}

