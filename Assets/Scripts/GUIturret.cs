using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIturret : MonoBehaviour {

    [SerializeField]
    private bool visible;

    // Use this for initialization
    void Start () {
        if (!visible)
        {
            MakeInvisible();
        }
	}

    /// <summary>
    /// Make the Canvas visible
    /// </summary>
    public void MakeVisible()
    {
        GetComponent<CanvasGroup>().alpha = 1 ;
        return;
    }

    /// <summary>
    /// Make the canvas invisible
    /// </summary>
    public void MakeInvisible()
    {
        GetComponent<CanvasGroup>().alpha = 0;
        return;
    }
}
