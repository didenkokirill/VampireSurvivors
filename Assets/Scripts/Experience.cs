using UnityEngine;

public class Experience : MonoBehaviour
{
    public int value;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ExperienceManager.Instance.AddExp(value);
            value = 0;
            Destroy(gameObject);
        }
    }
}
