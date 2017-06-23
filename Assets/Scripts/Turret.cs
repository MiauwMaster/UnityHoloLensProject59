using UnityEngine;

public class Turret : MonoBehaviour {

	#region Variables
	private Transform target;
	
	[Header("General")]
	public float range = 15f;
    public int price;
	public bool useCannon = false;

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

	[Header("Missile")]
	public bool isMissile = false;

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
	
	void UpdateTarget()
	{
        IsUpgraded();

		GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

		float shortestDistance = Mathf.Infinity;
		GameObject nearestEnemy = null;


		foreach(GameObject enemy in enemies)
		{
			float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
			if(distanceToEnemy < shortestDistance)
			{
				shortestDistance = distanceToEnemy;
				nearestEnemy = enemy;
			}
		}

		if(nearestEnemy != null && shortestDistance <= range)
		{
			target = nearestEnemy.transform;
		}
		else
		{
			target = null;
		}
	}

	void Update () {
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

		LockOnTarget();

		if (useLaser)
		{
			Laser();
		}
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

	void LockOnTarget()
	{
		Vector3 dir = target.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation(dir);
		Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
		partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
	}

	void Laser()
	{
		if (!lineRenderer.enabled)
			lineRenderer.enabled = true;

		lineRenderer.SetPosition(0, firePoint.position);
		lineRenderer.SetPosition(1, target.position);
	}

	void Shoot()
	{
		GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
		Bullet bullet = bulletGo.GetComponent<Bullet>();

		if(bullet != null)
		{

            bullet.damage = damage;
			

			bullet.Seek(target);
			if (useLaser)
			{
				target.GetComponent<MoveToPlayer>().speed /= slowingAmount;
				FindObjectOfType<SoundManager>().Play("");
			}
			if (useCannon)
			{
				FindObjectOfType<SoundManager>().Play("GunSound");
			}
			if (isMissile)
			{
				FindObjectOfType<SoundManager>().Play("");
			}
		}
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, range);
	}

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

