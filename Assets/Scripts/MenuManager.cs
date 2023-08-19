using System.Collections;
using TMPro;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    [SerializeField] private GameObject updateMenu, gameOverMenu;
    [SerializeField] private float timeToResume;
    [SerializeField] private TMP_Text timerResume;

    private void Awake() => Instance = this;

    private bool onPause;

    private void Update()
    {
        if (onPause)
        {
            Time.timeScale = 0;
        }
        else if (!onPause)
        {
            Time.timeScale = 1.0f;
        }
    }

    public void PutOnPause()
    {
        onPause = true;
    }
    public void RemoveFromPause()
    {
        StartCoroutine(CountDown(timeToResume));
    }

    public void OpenUpdateMenu()
    {
        updateMenu.SetActive(true);
        PutOnPause();
    }
    public void CloseUpdateMenu()
    {
        updateMenu.SetActive(false);
        RemoveFromPause();
    }

    public void OpenGameOverMenu()
    {
        ScoreManager.Instance.UpdateScoresTexts();
        gameOverMenu.SetActive(true);
        PutOnPause();
    }

    private IEnumerator CountDown(float time) // check code stile
    {
        while (true)
        {
            timerResume.text = Mathf.Round(time).ToString();
            time--;
            yield return new WaitForSecondsRealtime(1);

            if (time <= 0)
            {
                timerResume.enabled = false;
                onPause = false;
                yield return null;
            }
        }
    }
}
