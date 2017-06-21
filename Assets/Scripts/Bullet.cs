using UnityEngine;

public class Bullet : MonoBehaviour {

	#region Variables
	private Transform target;
    public float damage;
	public float speed = 70f;
	#endregion


	#region Unity Methods
	public void Seek (Transform _target)
	{
		target = _target;
	}

	void Update ()
	{
		if(target == null)
		{
			Destroy(gameObject);
			return;
		}

		Vector3 dir = target.position - transform.position;
		float distanceThisFrame = speed * Time.deltaTime;

		if(dir.magnitude <= distanceThisFrame)
		{
			HitTarget();
			return;
		}

		transform.Translate(dir.normalized * distanceThisFrame, Space.World);
       
	}

	void HitTarget()
	{
        target.GetComponent<Enemy>().LoseLife(damage);

		Destroy(gameObject);
	}

    #endregion
}

