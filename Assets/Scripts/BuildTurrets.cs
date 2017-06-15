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
		var direction = headRay.direction;
		var origin = headRay.origin;
		var position = origin + direction * 2.0f;

		Instantiate(turret, position, Quaternion.identity);
	}

	//void OnMouseDown()
	//{

	//	Debug.Log("hit1");
	//	Vector3 fwd = transform.TransformDirection(Vector3.forward);

	//	if (Physics.Raycast(transform.position, fwd, distance))
	//	{
	//		Debug.Log("hit2");
	//		Instantiate(turret, turret.transform.position, turret.transform.rotation);
	//	}
	//}
	#endregion
}


