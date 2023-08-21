using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    [SerializeField] private GameObject updateMenu, gameOverMenu, secondLifeButton;
    [SerializeField] private float timeToResume;
    [SerializeField] private TMP_Text timerResume;
    private bool giveSecondLife = true;

    private void Awake() => Instance = this;

    public void PutOnPause()
    {
        Time.timeScale = 0;
    }
    public void RemoveFromPause()
    {
        Time.timeScale = 1.0f;
    }

    public void OpenUpdateMenu()
    {
        updateMenu.SetActive(true);
        PutOnPause();
    }
    public void CloseUpdateMenu()
    {
        updateMenu.SetActive(false);
        StartCoroutine(CountDown(timeToResume));
    }

    public void OpenGameOverMenu()
    {
        ScoreManager.Instance.UpdateScoresTexts();
        gameOverMenu.SetActive(true);
        if(giveSecondLife == false)
        {
            secondLifeButton.SetActive(false);
        }

        PutOnPause();
    }
    public void CloseGameOverMenu()
    {
        gameOverMenu.SetActive(false);
        CountEnemies.Instance.ResetEnemy();
        PlayerController.Instance.RessurectPlayer();

        giveSecondLife = false;
        GameManager.Instance.ShowAdForNewLife();
        ScoreManager.Instance.ChangeBestScore();

        StartCoroutine(CountDown(timeToResume));
    }

    private IEnumerator CountDown(float time = 3) // check code stile
    {
        timerResume.enabled = true;
        while (true)
        {
            timerResume.text = Mathf.Round(time).ToString();
            time--;
            yield return new WaitForSecondsRealtime(1);

            if (time <= 0)
            {
                timerResume.enabled = false;;
                RemoveFromPause();
                yield break;
            }
        }
    }
}
