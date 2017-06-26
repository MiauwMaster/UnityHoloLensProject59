using UnityEngine;

public class Bullet : MonoBehaviour {

	#region Variables
	private Transform target;
    public float damage;
	public float speed = 70f;
	#endregion


	#region Unity Methods
    /// <summary>
    /// Set the target
    /// </summary>
    /// <param name="_target">Target</param>
	public void Seek (Transform _target)
	{
		target = _target;
	}

	void Update ()
	{
        //If target is null, return
		if(target == null)
		{
			Destroy(gameObject);
			return;
		}

        //set target position
		Vector3 dir = target.position - transform.position;
		float distanceThisFrame = speed * Time.deltaTime;

        //If bullet si at the same position as the target
		if(dir.magnitude <= distanceThisFrame)
		{
            //hit the target and return
			HitTarget();
			return;
		}

        //move towards the target
		transform.Translate(dir.normalized * distanceThisFrame, Space.World);
       
	}

    /// <summary>
    /// Deal gunDamage to the target and destroy bullet
    /// </summary>
	void HitTarget()
	{
        target.GetComponent<Enemy>().LoseLife(damage);

		Destroy(gameObject);
	}

    #endregion
}

