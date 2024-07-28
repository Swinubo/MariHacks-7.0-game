using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Collector : MonoBehaviour
{
    private Rigidbody2D rb;

    public static List<Creature> have_rizkamons = new List<Creature>();

    [SerializeField] private GameObject[] rizkamonsSER;
    public static GameObject[] rizkamons;

    public static Creature currentRizkamon;
    public static Creature initcurrentRizkamon;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rizkamons = rizkamonsSER;

        currentRizkamon = Creature.Richard;
        initcurrentRizkamon = currentRizkamon;
    }

    private void Update()
    {
        /*if (have_rizkamons.Count == rizkamonsSER.Length)
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

