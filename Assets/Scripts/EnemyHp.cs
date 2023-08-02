using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    [SerializeField] private int hp;

    //private void Update()
    //{
    //    var renderer = GetComponent<Renderer>();
    //    var lerpedColor = Color.Lerp(Color.red, Color.white, Mathf.PingPong(Time.time, 1));
    //    renderer.material.color = lerpedColor;
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            hp -= 1;

            var renderer = GetComponent<Renderer>();
            renderer.material.color = Color.Lerp(Color.red, Color.white, 0.2f * hp);

            if (collision.CompareTag("Bullet"))
            {
                Destroy(collision.gameObject);
            }
            
            if (hp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
