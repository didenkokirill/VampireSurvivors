using UnityEngine;

public class Example : MonoBehaviour
{
    // Adjust the speed for the application.
    public float speed = 1.0f;

    // The target (cylinder) position.
    [SerializeField] private Transform target;

    void Awake()
    {
        // Position the cube at the origin.
        transform.position = new Vector3(0.0f, 0.0f, 0.0f);
    }

    void Update()
    {
        // Move our position a step closer to the target.
        var step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        // Check if the position of the cube and sphere are approximately equal.
        if (Vector3.Distance(transform.position, target.position) < 0.001f)
        {
            // Swap the position of the cylinder.
            target.position *= -1.0f;
        }
    }
}
