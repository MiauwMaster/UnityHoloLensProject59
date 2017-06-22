using UnityEngine;
using UnityEngine.VR.WSA.Input;

public class BuildTurrets : MonoBehaviour {

	#region Variables
	public GameObject turret;
	public GameObject buildEffect;

	GestureRecognizer recognizer;

	#endregion


	#region Unity Methods

	private void Start()
	{
		recognizer = new GestureRecognizer();
		recognizer.TappedEvent += Recognizer_TappedEvent;
		recognizer.StartCapturingGestures(); 
	}

	void Recognizer_TappedEvent(InteractionSourceKind source,int tapCount, Ray headRay)
	{
        if (turret != null)
        {
            if (Camera.main.GetComponent<Player>().money >= turret.GetComponent<Turret>().price)
            {
                GameObject effectins = (GameObject)Instantiate(buildEffect, this.transform.position, this.transform.rotation);
                Destroy(effectins, 2.0f);

                GameObject go = Instantiate(turret, this.transform.position, this.transform.rotation);
				if(go.tag == "NonUpgradedTurret")
                {
                    GetComponent<UpgradeTurrets>().Add(go);
                }
                Camera.main.GetComponent<Player>().LoseMoney(turret.GetComponent<Turret>().price);
            }
        }
	}
	#endregion
}


