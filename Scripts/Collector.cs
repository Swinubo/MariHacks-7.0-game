using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Collector : MonoBehaviour
{
    private Rigidbody2D rb;

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

