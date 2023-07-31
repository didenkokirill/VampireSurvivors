using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidBody;

    [SerializeField] private float speed;

    [SerializeField] private KeyCode up;
    [SerializeField] private KeyCode down;
    [SerializeField] private KeyCode left;
    [SerializeField] private KeyCode right;

    private void Update()
    {
        Vector2 direction = Vector2.zero;

        if (Input.GetKey(up))
        {
            direction += Vector2.up;
        }

        if (Input.GetKey(down))
        {
            direction += Vector2.down;
        }

        if (Input.GetKey(left))
        {
            direction += Vector2.left;
        }

        if (Input.GetKey(right))
        {
            direction += Vector2.right;
        }

        rigidBody.velocity = direction * speed;
    }
}
