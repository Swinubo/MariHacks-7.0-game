using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Collector : MonoBehaviour
{
    private Rigidbody2D rb;

    public static bool have_bip = false;
    public static bool have_punny = false;
    public static bool have_richard = false;
    public static bool have_joe = false;
    public static bool have_alvin = false;
    public static bool have_whale = false;

    [SerializeField] private GameObject[] rizkamonsSER;
    public static GameObject[] rizkamons;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rizkamons = rizkamonsSER;
    }

    private void Update()
    {
        if (have_bip && have_punny && have_richard && have_joe && have_alvin && have_whale)
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

