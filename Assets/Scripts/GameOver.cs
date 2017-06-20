using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    public Texture gameOverTexture;

    void OnGUI()
    {
        if (Camera.main.GetComponent<Player>().isAlive == false)
        {
            GetComponent<Text>().enabled = true; 
        }
        
    }
}
