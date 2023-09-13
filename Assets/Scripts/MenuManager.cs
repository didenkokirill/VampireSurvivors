using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    [SerializeField] private GameObject onGamePlay, updateMenu, gameOverMenu, shopMenu, secondLifeButton;
    [SerializeField] private float timeToResume;
    [SerializeField] private TMP_Text timerResume;
    private bool giveSecondLife = true;

    private void Awake()
    {
        Instance = this;
        giveSecondLife = true;
    }

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
        SaveManager.Instance.UpdateScoresTexts();
        gameOverMenu.SetActive(true);
       
        secondLifeButton.SetActive(giveSecondLife);
        
        PutOnPause();
    }
    public void CloseGameOverMenu()
    {
        gameOverMenu.SetActive(false);
        CountEnemies.Instance.ResetEnemy();
        PlayerController.Instance.RessurectPlayer();

        SaveManager.Instance.SaveBestScore();

        StartCoroutine(CountDown(timeToResume));
    }
    public void GiveSecondLive()
    {
        giveSecondLife = false;
        GameManager.Instance.ShowAdForNewLife();
    }

    public void OpenShopMenu()
    {
        onGamePlay.SetActive(false);
        shopMenu.SetActive(true);
    }

    public IEnumerator CountDown(float time = 3) // check code stile
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
