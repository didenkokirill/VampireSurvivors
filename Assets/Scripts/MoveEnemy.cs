using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    // Adjust the speed for the application.
    public float speed = 1.0f;

    // The target (cylinder) position.
    public Transform target;

    void Awake()
    {
        // Position the cube at the origin.
        transform.position = GetComponent<Transform>().position; // FEEDBACK: ты здесь пишешь "масло = масло" (:
        // transform.position это и есть GetComponent<Transform>().position
        // можешь убрать этот кусочек кода
    }

    void Update()
    {
        // Move our position a step closer to the target.
        var step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }
}
