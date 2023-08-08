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


    //private void Update()
    //{
    //    var renderer = GetComponent<Renderer>();
    //    var lerpedColor = Color.Lerp(Color.red, Color.white, Mathf.PingPong(Time.time, 1));
    //    renderer.material.color = lerpedColor;
    //}
}
