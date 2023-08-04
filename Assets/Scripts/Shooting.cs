using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bullet;

    [SerializeField] private float attackDelay = 5;
    [SerializeField] public float range = 10;
    [SerializeField] private float forse;
    
    
    private float attackTimer;

    private void Update()
    {
        GameObject nearestTarget = GetComponentInParent<FindNearest>().nearest;

        attackTimer++;
        if (attackTimer > attackDelay)
        {
            if (Vector3.Distance(transform.position, nearestTarget.transform.position) <= range)
            {
                attackTimer = 0;
                Shoot();
            }          
        }
    }

    public void Shoot()
    {      
        GameObject clone = Instantiate(bullet, transform.position, transform.rotation);
        Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * forse, ForceMode2D.Impulse);
    }
}
