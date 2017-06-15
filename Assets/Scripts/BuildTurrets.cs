using UnityEngine;

public class BuildTurrets : MonoBehaviour {

	#region Variables
	public Transform turret;

	private float distance = 15f;

	#endregion

	
	#region Unity Methods

	void OnMouseDown()
	{
		Vector3 fwd = transform.TransformDirection(Vector3.forward);

		if (Physics.Raycast(transform.position , fwd, distance))
		{
			Instantiate(turret, turret.transform.position, turret.transform.rotation);
		}
	}
	#endregion
}


