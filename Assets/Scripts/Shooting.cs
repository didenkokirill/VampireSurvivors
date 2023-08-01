using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private float attackDelay = 5;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float forse;
    [SerializeField] private Transform firePoint;
    
    private float attackTimer;

    private void Update()
    {
        attackTimer++;
        if (attackTimer > attackDelay)
        {
            attackTimer = 0;
            Shoot();
        }
    }

    public void Shoot()
    {      
        GameObject clone = Instantiate(bullet, transform.position, transform.rotation);
        Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * forse, ForceMode2D.Impulse);
    }
}
