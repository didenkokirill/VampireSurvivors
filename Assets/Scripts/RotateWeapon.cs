using UnityEngine;

public class RotateWeapon : MonoBehaviour
{
    [SerializeField] private FindNearest findNearest;
    [SerializeField] private float rotationSensitivity = 5;

    void Update()
    {
        if (findNearest.nearest != null)
        {
            GameObject nearestTarget = findNearest.nearest;
       
            Quaternion direction = Quaternion.LookRotation(Vector3.forward, nearestTarget.transform.position - transform.position);

            transform.rotation = Quaternion.Lerp(transform.rotation, direction, rotationSensitivity * Time.deltaTime);
        }
    }
}