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
        if (Player_Movement.use_buttons)
        {
            TurnOnButtonImages();
        }
    }    

    // Method called when button is pressed
    public void OnPointerDown(BaseEventData eventData)
    {
        PointerEventData pointerEventData = eventData as PointerEventData;
        if (pointerEventData.pointerEnter.name == "Left")
        {
            Player_Movement.dirX = -1;
        }
        else if (pointerEventData.pointerEnter.name == "Right")
        {
            Player_Movement.dirX = 1;
        }

        if (pointerEventData.pointerEnter.name == "Up")
        {
            Player_Movement.dirY = 1;
        }
        else if (pointerEventData.pointerEnter.name == "Down")
        {
            Player_Movement.dirY = -1;
        }
    }

    // Method called when button is released
    public void OnPointerUp(BaseEventData eventData)
    {
        PointerEventData pointerEventData = eventData as PointerEventData;
        if (pointerEventData.pointerEnter.name == "Left")
        {
            Player_Movement.dirX = 0;
        }
        else if (pointerEventData.pointerEnter.name == "Right")
        {
            Player_Movement.dirX = 0;
        }
        
        if (pointerEventData.pointerEnter.name == "Up")
        {
            Player_Movement.dirY = 0;
        }
        else if (pointerEventData.pointerEnter.name == "Down")
        {
            Player_Movement.dirY = 0;
        }
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
        GameObject.Find("Right").GetComponent<Image>().enabled =true;
        GameObject.Find("Left").GetComponent<Image>().enabled =true;
        GameObject.Find("Up").GetComponent<Image>().enabled =true;
        GameObject.Find("Down").GetComponent<Image>().enabled =true;
        GameObject.Find("Right").GetComponent<Button>().enabled =true;
        GameObject.Find("Left").GetComponent<Button>().enabled =true;
        GameObject.Find("Up").GetComponent<Button>().enabled =true;
        GameObject.Find("Down").GetComponent<Button>().enabled =true;
    }

    private void TurnOffButtonImages()
    {
        Player_Movement.use_buttons = false;
        activateButtonsText.text = "Activate Buttons";
        GameObject.Find("Right").GetComponent<Image>().enabled =false;
        GameObject.Find("Left").GetComponent<Image>().enabled =false;
        GameObject.Find("Up").GetComponent<Image>().enabled =false;
        GameObject.Find("Down").GetComponent<Image>().enabled =false;
        GameObject.Find("Right").GetComponent<Button>().enabled =false;
        GameObject.Find("Left").GetComponent<Button>().enabled =false;
        GameObject.Find("Up").GetComponent<Button>().enabled =false;
        GameObject.Find("Down").GetComponent<Button>().enabled =false;
    }
}
