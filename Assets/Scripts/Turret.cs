using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {

	#region Variables
	private Transform target;

	[Header("General")]
	public float range = 15f;
    public int price;

	[Header("Gun")]
	public float gunFireRate = 1f;
    public float gunDamage = 1;
    public bool useCannon = false;

    [Header("Ugrades")]
    public float fireRateMultiplier;
    public float upgradedDamage;
    public bool upgraded = false;

    float upgradedFireRate;
    private float fireCountDown = 0f;

	[Header("laser")]
	public bool useLaser = false;
	private float slowingAmount = 2f;
	public LineRenderer lineRenderer;
	private float oldSpeed = 1.5f;

	[Header("Missile")]
	public bool isMissile = false;
    public float missileDamage = 10;
    public float missileFireRate = 0.2f;


	[Header("Unity Setup!")]
	public float turnSpeed = 10f;
	public Transform partToRotate;

	public string enemyTag = "Enemy";
	public GameObject bulletPrefab;
	public GameObject missilePrefab;
	public Transform firePoint;


	#endregion

	
	#region Unity Methods
	
	void Start () {
		InvokeRepeating("UpdateTarget", 0f, 0.5f);
        upgradedFireRate = gunFireRate * fireRateMultiplier;
	}
	
    /// <summary>
    /// update the target
    /// </summary>
	void UpdateTarget()
	{
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
			bool newTarget = false;
			if(useLaser && target != nearestEnemy)
			{
				newTarget = true;
				if (target != null)
					target.GetComponent<MoveToPlayer>().speed /= oldSpeed; //resetting speed when target changes
			}

			target = nearestEnemy.transform;

			if(useLaser && newTarget)
			{
				target.GetComponent<MoveToPlayer>().speed /= slowingAmount; //slow new target
			}
		}

        //If there are no enemies, target is null.
		else
		{
			target = null;
		}
	}

	void Update ()
    {
        //Check if the turret is upgraded
        IsUpgraded();

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

        //If the turret is a laser, use the laser
		if (useLaser)
		{
			Laser();
            if(lineRenderer.enabled == true)
            {
				SoundManager.instance.Play("LaserSound");
            }
        }

		else
		{
			if (fireCountDown <= 0f)
			{
                //Shoot missile if the turret is a gun turret 
				if (isMissile)
				{
					ShootMissle();
                    fireCountDown = 1f / missileFireRate;
                }
                //If turret is a cannon, shoot bullets.
				else if(useCannon)
				{
					Shoot();
                    fireCountDown = 1f / gunFireRate;
                }
				
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

	float time = 0;
	void Laser()
	{
		if (!lineRenderer.enabled)
		{
			lineRenderer.enabled = true;
		}
		
		lineRenderer.SetPosition(0, firePoint.position);
		lineRenderer.SetPosition(1, target.position);

		if (!lineRenderer.enabled)
		{
			//target.GetComponent<MoveToPlayer>().speed = oldSpeed;
		}
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

            bullet.damage = gunDamage;
			FindObjectOfType<SoundManager>().Play("GunSound");

			bullet.Seek(target);
			
		}
	}

	void ShootMissle()
	{
		GameObject missileGo = (GameObject)Instantiate(missilePrefab, firePoint.position, firePoint.rotation);
		Missile missile = missileGo.GetComponent<Missile>();

		if (missile != null)
		{

			missile.damage = missileDamage;

			missile.Seek(target);

		}
	}

	/// <summary>
	/// Draw range for turrets in game scene
	/// </summary>
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
            gunFireRate = upgradedFireRate;
            gunDamage = upgradedDamage;
        }
    }
	#endregion
}

