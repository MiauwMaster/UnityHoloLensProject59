using UnityEngine;

public class Turret : MonoBehaviour {

	#region Variables
	private Transform target;
	
	[Header("General")]
	public float range = 15f;
    public int price;

	[Header("Bullets Default")]
	public float fireRate = 1f;
    public float damage = 1;

    [Header("Ugrades")]
    public float fireRateMultiplier;
    float upgradedFireRate;
    public float upgradedDamage;

    private float fireCountDown = 0f;
	public bool upgraded = false;

	[Header("laser")]
	public bool useLaser = false;
	public float slowingAmount;
	public LineRenderer lineRenderer;

	[Header("Unity Setup!")]
	public float turnSpeed = 10f;
	public Transform partToRotate;

	public string enemyTag = "Enemy";
	public GameObject bulletPrefab;
	public Transform firePoint;


	#endregion

	
	#region Unity Methods
	
	void Start () {
		InvokeRepeating("UpdateTarget", 0f, 0.5f);
        upgradedFireRate = fireRate * fireRateMultiplier;
	}
	
    /// <summary>
    /// update the target
    /// </summary>
	void UpdateTarget()
	{
        //Check if the turrt is upgraded
        IsUpgraded();

        //Find all enemies and store them in an array
		GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

		float shortestDistance = Mathf.Infinity;
		GameObject nearestEnemy = null;

        //Find the closest enemy
		foreach(GameObject enemy in enemies)
		{
			float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
			if(distanceToEnemy < shortestDistance)
			{
				shortestDistance = distanceToEnemy;
				nearestEnemy = enemy;
			}
		}

        //Set the nearest enemy as target
		if(nearestEnemy != null && shortestDistance <= range)
		{
			target = nearestEnemy.transform;
		}

        //If there are no enemies, target is null.
		else
		{
			target = null;
		}
	}

	void Update () {
        //If target is null, and turret is a laser, disable line renderer
		if (target == null)
		{
			if (useLaser)
			{
				if (lineRenderer.enabled)
				{
					lineRenderer.enabled = false;
				}
			}
			return;
		}

        //Lock on to the target
		LockOnTarget();

        //If it's a laser, use the laser
		if (useLaser)
		{
			Laser();
		}

        //Else shoot bullets
		else
		{
			if (fireCountDown <= 0f)
			{
				Shoot();
				fireCountDown = 1f / fireRate;
			}

			fireCountDown -= Time.deltaTime;
		}



	}

    /// <summary>
    /// Lock onto the target
    /// </summary>
	void LockOnTarget()
	{
		Vector3 dir = target.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation(dir);
		Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
		partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
	}

    /// <summary>
    /// Shoot the laser
    /// </summary>
	void Laser()
	{
		if (!lineRenderer.enabled)
			lineRenderer.enabled = true;

		lineRenderer.SetPosition(0, firePoint.position);
		lineRenderer.SetPosition(1, target.position);
	}

    /// <summary>
    /// Shoot bullets and play the bullet sound
    /// </summary>
	void Shoot()
	{
		GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
		Bullet bullet = bulletGo.GetComponent<Bullet>();

		if(bullet != null)
		{

            bullet.damage = damage;
			FindObjectOfType<SoundManager>().Play("GunSound");

			bullet.Seek(target);
			if (useLaser)
			{
				target.GetComponent<MoveToPlayer>().speed /= slowingAmount;
			}
		}
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, range);
	}

    /// <summary>
    /// check if the turret is upgraded and upgrade it
    /// </summary>
    void IsUpgraded()
    {
        if (upgraded)
        {
            fireRate = upgradedFireRate;
            damage = upgradedDamage;
        }
    }
	#endregion
}

