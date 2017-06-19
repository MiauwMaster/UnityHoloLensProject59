using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

    public Texture gameOverTexture;


    void OnGUI()
    {
        if(GetComponent<Player>().isAlive == false)
        {
          GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), gameOverTexture);
        }
        
    }
}
