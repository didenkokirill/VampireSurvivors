using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Transform[] firePoints;
    [SerializeField] private GameObject bullet;

    [SerializeField] private int weaponNum;
    
    [SerializeField] private float attackDelay = 5;
    [SerializeField] private float attackRange = 10;
    [SerializeField] private float bulletForse = 30;
    [SerializeField] private float bulletDamage = 1;
    [Header("Rocket Laucher")]
    [SerializeField] private float splashDamage = 1;
    [SerializeField] private float splashRange = 0;

    private float attackTimer;
   
    private void Update()
    {
        GameObject nearestTarget = GetComponentInParent<FindNearest>().nearest;

        attackTimer++;
        if (attackTimer > attackDelay)
        {
            if(nearestTarget != null)
            {
                if (Vector3.Distance(transform.position, nearestTarget.transform.position) <= attackRange)
                {
                    if (weaponNum == 1)
                    {
                        MachineGunShoot();
                    }
                    if (weaponNum == 2)
                    {
                        ShotGunShoot();
                    }
                    if(weaponNum == 3)
                    {
                        RocketLauncherShoot();
                    }

                    attackTimer = 0;
                }
            }           
        }
    }

    private void MachineGunShoot()
    {      
        GameObject clone = Instantiate(bullet, firePoints[0].transform.position, firePoints[0].transform.rotation);
        Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();
        clone.GetComponent<Bullet>().damage = bulletDamage;
        rb.AddForce(firePoints[0].up * bulletForse, ForceMode2D.Impulse);
    }

    private void ShotGunShoot()
    {
        for (var i = 0; i < firePoints.Length; i++)
        {
            GameObject clone = Instantiate(bullet, firePoints[i].transform.position, firePoints[i].transform.rotation);
            clone.GetComponent<Bullet>().damage = bulletDamage;
            Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoints[i].up * bulletForse, ForceMode2D.Impulse);
        }
    }

    private void RocketLauncherShoot()
    {
        GameObject clone = Instantiate(bullet, firePoints[0].transform.position, firePoints[0].transform.rotation);
        clone.GetComponent<Bullet>().damage = splashDamage;
        clone.GetComponent<Bullet>().splashRange = splashRange;
        Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoints[0].up * bulletForse, ForceMode2D.Impulse);
    }
}
