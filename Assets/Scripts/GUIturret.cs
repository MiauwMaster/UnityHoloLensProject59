using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIturret : MonoBehaviour {

    [SerializeField]
    private bool visible;
    [SerializeField]
    private bool isActive;

    public bool IsActive { get; internal set;}




    // Use this for initialization
    void Start () {
        IsActive = true;
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
        IsActive = true;
        return;
    }
    public void MakeInvisible()
    {
        GetComponent<CanvasGroup>().alpha = 0;
        IsActive = false;
        return;
    }
}
