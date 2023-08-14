using UnityEngine;

public class RotateWeapon : MonoBehaviour
{
    [SerializeField] private float rotationSensitivity;

    [SerializeField] private Rigidbody2D rb;

    private FindNearest findNearest;

    void Start()
    {
        findNearest = GetComponent<FindNearest>();
    }

    void Update()
    {
        if (findNearest.nearest != null)
        {
            GameObject nearestTarget = findNearest.nearest;
            Vector3 targetPos = nearestTarget.transform.position;
            var angle = Vector2.Angle(Vector2.up, targetPos - transform.position);
            transform.eulerAngles = new Vector3(0f, 0f, angle);
        }
    }
}
