using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetOutOfStart : MonoBehaviour
{
    public void OnStart(){
        GameObject.Find("ButtonToStart").GetComponent<Image>().enabled =false; 
        GameObject.Find("ButtonToStart").GetComponent<Button>().enabled =false; 
        GameObject.Find("TextToStart").GetComponent<Text>().enabled =false; 
    }
}
