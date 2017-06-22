using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthscript : MonoBehaviour {

    [SerializeField]
    private float fillAmount;
    [SerializeField]
    private Image content;

    public Player Player;
    public float Value { set { fillAmount = Mapper(value); } }
                                       // Use this for initialization
    void Start () {
        Value = 5;
	}
	
	// Update is called once per frame
	void Update () {
        Barcontrol();
        Value = Player.health;
	}
    private void Barcontrol()
    {
        if (fillAmount != content.fillAmount)
        {
            content.fillAmount = fillAmount;
        }
    }
    private float Mapper(float value)
    {
        return value / 5;
    }
}   
