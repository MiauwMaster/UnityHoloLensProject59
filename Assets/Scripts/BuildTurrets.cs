using UnityEngine;
using UnityEngine.VR.WSA.Input;

public class BuildTurrets : MonoBehaviour {

	#region Variables
	public GameObject turret;

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
        if (Camera.main.GetComponent<Player>().money >= turret.GetComponent<Turret>().price)
        {
            Instantiate(turret, this.transform.position, this.transform.rotation);
            Camera.main.GetComponent<Player>().LoseMoney(turret.GetComponent<Turret>().price);
        }


	}
	#endregion
}


