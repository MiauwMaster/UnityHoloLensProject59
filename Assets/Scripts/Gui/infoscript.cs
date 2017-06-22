using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class infoscript : MonoBehaviour {

    [SerializeField]
    private GUIturret cannon;
    [SerializeField]
    private GUIturret laser;
    [SerializeField]
    private GUIturret missle;
    [SerializeField]
    private Text cannonT;
    [SerializeField]
    private Text laserT;
    [SerializeField]
    private Text missleT;
    private bool nowvisible;

    public bool Nowvisible { get; internal set; }

    // Use this for initialization
    void Start () {
        MakeInvisible();
	}
	
	// Update is called once per frame
	void Update () {
        if (nowvisible)
        {
            if (laser.IsActive)
            {
                laserT.GetComponent<CanvasGroup>().alpha = 1;
                missleT.GetComponent<CanvasGroup>().alpha = 0;
                cannonT.GetComponent<CanvasGroup>().alpha = 0;
            } else if (missle.IsActive)
            {
                laserT.GetComponent<CanvasGroup>().alpha = 0;
                missleT.GetComponent<CanvasGroup>().alpha = 1;
                cannonT.GetComponent<CanvasGroup>().alpha = 0;
            } else if (cannon.IsActive)
            {
                laserT.GetComponent<CanvasGroup>().alpha = 0;
                missleT.GetComponent<CanvasGroup>().alpha = 0;
                cannonT.GetComponent<CanvasGroup>().alpha = 1;
            }
        }
	}
    public void MakeVisible()
    {
        GetComponent<CanvasGroup>().alpha = 1;
        nowvisible = true;
        return;
    }
    public void MakeInvisible()
    {
        GetComponent<CanvasGroup>().alpha = 0;
        nowvisible = false;
        return;
    }
    
}
