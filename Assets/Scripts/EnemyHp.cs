using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    [SerializeField] private float hp;
    private Renderer rendr;

    private void Awake()
    {
        rendr = GetComponent<Renderer>();
    }

    private void Update()
    {
        rendr.material.color = Color.Lerp(Color.red, Color.white, 0.2f * hp);

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeHit(float damage)
    {
        hp -= damage;
    }
}
