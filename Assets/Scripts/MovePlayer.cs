using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationSensitivity;

    [SerializeField] private Rigidbody2D rb;

    private Vector2 directionMove;
    private FindNearest findNearest;

    private void Start()
    {
        findNearest = GetComponent<FindNearest>();
    }

    private void Update()
    {
        directionMove.x = Input.GetAxisRaw("Horizontal");
        directionMove.y = Input.GetAxisRaw("Vertical");
    } 

    private void FixedUpdate()
    {
        if (GetComponent<FindNearest>().nearest != null)
        {
            GameObject nearestTarget = findNearest.nearest;
            Vector2 targetPos = nearestTarget.transform.position;
            Vector2 lookDir = targetPos - rb.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;
        } 

        rb.MovePosition(rb.position + speed * Time.deltaTime * directionMove);
    }
}
