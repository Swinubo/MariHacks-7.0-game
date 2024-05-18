using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class send_to_rizzalations : MonoBehaviour
{
    string target= "https://tiaswinuba.itch.io/rizzalations-jtfhydhlkytfdsde-edition";

    private void OnTriggerEnter2D()
    {
        System.Diagnostics.Process.Start(target);
    }
}
