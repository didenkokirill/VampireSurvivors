using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HpCount : MonoBehaviour
{
    [SerializeField] private int hpCount;
    [SerializeField] private int maxHp = 100;
    [SerializeField] private TMP_Text hpText;

    private void Start()
    {
        hpCount = maxHp;
    }

    private void Update()
    {
        hpText.text = hpCount.ToString();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            hpCount -= 1;
            if (hpCount <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
