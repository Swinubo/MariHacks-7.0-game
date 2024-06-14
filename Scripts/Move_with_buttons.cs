using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Move_with_buttons : MonoBehaviour//, IPointerDownHandler, IPointerUpHandler
{

    private Rigidbody2D rb;
    [SerializeField] private Text activateButtonsText;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (!Player_Movement.use_buttons)
        {
            TurnOffButtonImages();
        }
        else
        {
            TurnOnButtonImages();
        }

        Player_Movement.dirX = 0;
        Player_Movement.dirY = 0;
    }    

    public void ActivateButtons()
    {
        Debug.Log("Phase 1");
        if (!Player_Movement.use_buttons)
        {
            TurnOnButtonImages();
            Debug.Log("Phase 2");
        }
        else if (Player_Movement.use_buttons)
        {
            TurnOffButtonImages();
            Debug.Log("Phase 2");
        }
    }

    private void TurnOnButtonImages()
    {
        Player_Movement.use_buttons = true;
        activateButtonsText.text = "Deactivate Buttons";
    }

    private void TurnOffButtonImages()
    {
        Player_Movement.use_buttons = false;
        activateButtonsText.text = "Activate Buttons";
    }
}