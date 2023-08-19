using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    [SerializeField] private float speed;
    [SerializeField] private float rotationSensitivity;

    [SerializeField] private Rigidbody2D rb;
    private Camera cam;

    private Vector3 startTouchPos, movedTouchPos;
    private Vector3 directionMove;

    private bool isMobile = false;


    private void Awake() => Instance = this;

    private void Start()
    {
        cam = Camera.main;

        isMobile = GameManager.Instance.isMobile();
    }

    private void Update()
    {
        FollowCursor();
    }

    private void FollowCursor()
    {
        if (isMobile)
        {
            return;
        }

        var mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        directionMove = mousePosition - transform.position;
        rb.MovePosition(transform.position + speed * Time.deltaTime * directionMove);
    }
    private void FollowTouches()
    {
        if (!isMobile)
        {
            return;
        }

        if (Input.touchCount > 0)
        {;
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                // register first touch, remember that point on the screen
                startTouchPos = cam.ScreenToWorldPoint(Input.GetTouch(0).position);
            }

            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                // if touch moved -> get that movement all the time
                movedTouchPos = cam.ScreenToWorldPoint(Input.GetTouch(0).position);

                // get a direction from start touch to move touch and mormalize it
                directionMove = (movedTouchPos - startTouchPos).normalized;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ResetCord"))
        {
            transform.position = new Vector3(0, 0, 0);
        }
    }

    private void RessurectPlayer()
    {
        return;
    }
}
