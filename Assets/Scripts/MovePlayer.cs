using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private Rigidbody2D rb;

    private Vector3 directionMove;

    private void Update()
    {
        var mousePosition = Input.mousePosition; 
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);;
        directionMove = mousePosition - transform.position;
        rb.MovePosition(transform.position + speed * Time.deltaTime * directionMove);
    } 
}
