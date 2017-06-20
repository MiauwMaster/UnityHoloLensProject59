using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

    public Texture gameOverTexture;

    void OnGUI()
    {
          GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), gameOverTexture);
    }
}
