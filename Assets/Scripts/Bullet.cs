using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public float explosionRange;

    private void Awake()
    {
        Destroy(gameObject, 5);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyHp enemyHp = collision.GetComponent<EnemyHp>();
            if (enemyHp != null)
            {               
                if (explosionRange > 0)
                {
                    Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, explosionRange);
                    Debug.Log(hitColliders.LongLength);
                    foreach (var hitCollider in hitColliders)
                    {
                        if (hitCollider.CompareTag("Enemy"))
                        {
                            var closestPoint = hitCollider.ClosestPoint(transform.position);
                            var distance = Vector3.Distance(closestPoint, transform.position);
                            var damagePersent = Mathf.InverseLerp(explosionRange, 0, distance);
                            EnemyHp enemyHp1 = hitCollider.GetComponent<EnemyHp>();
                            enemyHp1.TakeHit(damagePersent * damage);
                        }
                    }
                }

                else
                {
                    enemyHp.TakeHit(damage);
                }
                Destroy(gameObject);
            }
        }
    }
}
