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
	
	// Update is called once per frame
	void Update () {
	}
    public void MakeVisible()
    {
        GetComponent<CanvasGroup>().alpha = 1 ;
        return;
    }
    public void MakeInvisible()
    {
        GetComponent<CanvasGroup>().alpha = 0;
        return;
    }
}
