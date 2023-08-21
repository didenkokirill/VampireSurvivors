using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    public float speed = 1.0f;
    public float damage = 1;

    public Transform target;
    
    private void Update()
    {
        var step = speed * Time.deltaTime; 
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<HealthSystem>().Damage(damage);
        }
    }
}
