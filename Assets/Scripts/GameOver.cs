using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    void OnGUI()
    {
        //If the player is dead
        if (Camera.main.GetComponent<Player>().isAlive == false)
        {
            //Enable the text component on GameObject
            GetComponent<Text>().enabled = true; 
        }
        
    }
}
