using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public float forse;
    public Transform firePoint;
    public float splashRange;

    private void Awake()
    {       
        //GetComponent<Rigidbody2D>().AddForce(firePoint.up * forse, ForceMode2D.Impulse);
     
        Destroy(gameObject, 5);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HealthSystem healthSystem = collision.GetComponent<HealthSystem>();

        if (!collision.CompareTag("Enemy"))
        {
            return;
        }
        
        if (splashRange > 0)
        {
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, splashRange);

            DamadeInRange(hitColliders);
        }

        if (healthSystem == null)
        {
            return;
        }

        else
        {
            healthSystem.Damage(damage);
        }
         
        Destroy(gameObject);
    }
    private void DamadeInRange(Collider2D[] hitColliders)
    {
        foreach (Collider2D hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Enemy"))
            {
                var closestPoint = hitCollider.ClosestPoint(transform.position); //bag?
                var distance = Vector3.Distance(closestPoint, transform.position);
                var damagePersent = Mathf.InverseLerp(splashRange, 0, distance);
                HealthSystem healthSystem = hitCollider.GetComponent<HealthSystem>(); 
                healthSystem.Damage(damagePersent * damage);
            }
        }
    }
    //private IEnumerator SpawnEnemyDelayed()
    //{

    //    GameObject explosion = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    //    explosion.transform.position = transform.position;
    //    explosion.GetComponent<MeshRenderer>().material.color = new Color(245, 241, 0, 0.1f);

    //    yield return new WaitForSeconds(waitToSpawn);

    //    Destroy(explosion);
    //}
}
