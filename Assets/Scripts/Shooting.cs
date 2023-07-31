using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private float attackDelay = 5;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject target;
    [SerializeField] private float speed;
    
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
        var clone = Instantiate(bullet, transform.position, transform.rotation);
        clone.GetComponent<Rigidbody2D>().velocity = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * speed);
        
    }
}
