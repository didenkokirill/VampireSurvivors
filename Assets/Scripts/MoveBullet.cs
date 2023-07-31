using UnityEngine;

public class MoveBullet : MonoBehaviour
{
    [SerializeField] private Transform target;

    private void Awake()
    {
        transform.position = new Vector3(0.0f, 0.0f, 0.0f);
    }
    private void Update()
    {
        var step = Time.deltaTime;
        Vector3.MoveTowards(transform.position, transform.position + new Vector3(1, 1), step);
    }
}
