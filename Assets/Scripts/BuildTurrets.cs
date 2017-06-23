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
        //If a turret is set
        if (turret != null)
        {
            //And if the player has enough money
            if (Camera.main.GetComponent<Player>().money >= turret.GetComponent<Turret>().price)
            {
                //Play the build particle effect
                GameObject effectins = (GameObject)Instantiate(buildEffect, this.transform.position, this.transform.rotation);
                Destroy(effectins, 2.0f);

                //instantiate the turret
                GameObject go = Instantiate(turret, this.transform.position, this.transform.rotation);

                //and if it is a cannon with tag "NonUpgradedTurret" add it to the list of non upgraded turrets
                if (go.tag == "NonUpgradedTurret")
                {
                    GetComponent<UpgradeTurrets>().Add(go);
                }

                //and remove the amount of money
                Camera.main.GetComponent<Player>().LoseMoney(turret.GetComponent<Turret>().price);
            }
        }
	}
	#endregion
}


