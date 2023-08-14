using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private enum Entity { Player, Enemy }
    [SerializeField] private Entity entity;
    [SerializeField] public int maxHealt;
    [SerializeField] public float health;
    [SerializeField] private TMP_Text healthText;
    [SerializeField] public CountEnemies countEnemys;
    private SpriteRenderer render;

    private void Update()
    {
        if (healthText != null)
        {
            healthText.text = health.ToString();
        }
    }

    private void Start()
    {
        render = GetComponent<SpriteRenderer>();
        health = maxHealt;
    }

    public float GetCurrentHealth()
    {
        return health;
    }

    public float GetMaxHealth()
    {
        return maxHealt;
    }
    public void Damage(float amount)
    {
        health -= amount;
        if (entity == Entity.Enemy)
        {
            render.material.color = Color.Lerp(Color.red, Color.white, 0.2f * health);
        }
        if (health <= 0)
        {
            Die();
        }
    }
    public void Heal(float amount)
    {
        health += amount;
        if (health > maxHealt)
        {
            health = maxHealt;
        }
    }

    private void Die()
    {       
        switch (entity)
        {
            case Entity.Player:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                break;
            case Entity.Enemy:
                countEnemys.Remove(gameObject);
                break;
        }
        Destroy(gameObject);
    }
    public void ChangeMaxHealth(int amount)
    {
        maxHealt += amount;
    }
}
