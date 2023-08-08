using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform transform;
    [SerializeField] private Camera cam;

    [SerializeField] private float speed;
    [SerializeField] private float rotationSensitivity;

    private Vector2 directionMove;


    private void Update()
    {
        directionMove.x = Input.GetAxisRaw("Horizontal");
        directionMove.y = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate()
    {
        if (GetComponent<FindNearest>().nearest != null)
        {
            GameObject nearestTarget = GetComponent<FindNearest>().nearest;
            Vector2 targetPos = nearestTarget.transform.position;
            Vector2 lookDir = targetPos - rb.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            Quaternion newRotation = new Quaternion(angle, 0, 0, 0);
            rb.rotation = angle;
        }    
        rb.MovePosition(rb.position + directionMove * speed * Time.deltaTime);   
    }
}
