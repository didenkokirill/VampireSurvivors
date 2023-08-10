using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    // FEEDBACK: Я бы советовал сначала показывать переменые, которые мы скорее всего будем изменять через Inspector,
    // а потом уже референсы к Rigidbody2D и так далее
    // так удобнее, сразу будешь видеть, что ты можешь изменить, а что не нужно

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform transform; // FEEDBACK: можно упростить. Можешь удалить эту строку и просто использовать transform
    [SerializeField] private Camera cam;

    [SerializeField] private float speed;
    [SerializeField] private float rotationSensitivity;

    private Vector2 directionMove;


    private void Update()
    {
        directionMove.x = Input.GetAxisRaw("Horizontal");
        directionMove.y = Input.GetAxisRaw("Vertical");
    } // FEEDBACK: пустая строка. (:
    private void FixedUpdate()
    {
        if (GetComponent<FindNearest>().nearest != null)
        {
            // FEEDBACK: чтобы не вызывать каждый раз компонент FindNearest и не тратить на это производительность,
            // ты можешь в Start прописать nearestTarget = GetComponent<FindNearest>();
            // а объявить FindNearest findNearest выше со всеми переменными
            GameObject nearestTarget = GetComponent<FindNearest>().nearest;
            Vector2 targetPos = nearestTarget.transform.position;
            Vector2 lookDir = targetPos - rb.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            Quaternion newRotation = new Quaternion(angle, 0, 0, 0); // FEEDBACK: это нигде не используется. Можешь удалять
            rb.rotation = angle;
        }     // FEEDBACK: пустая строка. (:
        rb.MovePosition(rb.position + directionMove * speed * Time.deltaTime);   // FEEDBACK: наведи на d в directionMove
        // тебе VS советует для preformance'а сделать reorder операций
        // Вообще совуют смотреть, что тебе VS советует с этими тремя точечками в виде подчёркивания
    }
}
