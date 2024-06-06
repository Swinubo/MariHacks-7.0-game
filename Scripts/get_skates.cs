using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class get_skates : MonoBehaviour
{
    public static bool have_skates = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            have_skates = true;
        }
    }
}
