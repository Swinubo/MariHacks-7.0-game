using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class get_swim : MonoBehaviour
{
    public static bool have_swim = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            have_swim = true;
        }
    }
}
