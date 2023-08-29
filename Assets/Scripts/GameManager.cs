using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void ShowAdv();
    
    [DllImport("__Internal")]
    private static extern void UnlockButtonsExtern();
    [DllImport("__Internal")]
    private static extern void ShowRewardedAdv();
    [DllImport("__Internal")]
    private static extern bool IsMobile();

    public static GameManager Instance { get; private set; }

    [SerializeField] private bool isTimeForRewardedAds;
    [SerializeField] private GameObject block;
    [SerializeField] private GameObject gameOverScreen, continueScreen;
    [SerializeField] private GameObject[] objectsToHideOnGameOver;
    [SerializeField] private GameObject b_secondLife, enemyKiller, startGameScreen;

    [SerializeField] private AudioYB source;

    private void Awake() => Instance = this;

    private void Start()
    {
#if !UNITY_EDITOR && UNITY_WEBGL
        ShowAdv();
#endif
        gameOverScreen.SetActive(false);
        startGameScreen.SetActive(true);

        Time.timeScale = 0;
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        startGameScreen.SetActive(false);
    }

    public void GameOver()
    {
        foreach (var objectToHide in objectsToHideOnGameOver)
        {
            objectToHide.SetActive(false);
        }

        gameOverScreen.SetActive(true);
        source.Play("toiletFlush");
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ShowAdForNewLife()
    {
        ShowRewardedAdv();
    }

    //public void GiveSecondLife()
    //{
    //    // remove secondLLife button
    //    b_secondLife.SetActive(false);

    //    // kill all enemies in radius
    //    Instantiate(enemyKiller, MovePlayer.Instance.transform.position, Quaternion.identity);

    //    // respawn player
    //    MovePlayer.Instance.RessurectPlayer();

    //    gameOverScreen.SetActive(false);

    //    foreach (var objectToHide in objectsToHideOnGameOver)
    //    {
    //        objectToHide.SetActive(true);
    //    }

    //    // resume game on button click
    //    /*gameOverScreen.SetActive(false);
    //    continueScreen.SetActive(true);*/
    //}

    public void CheckForShowingAd(int currentLevel)
    {
        // if this is NOT the first level and it is each 3d level
        if (currentLevel != 1 && currentLevel % 3 == 0)
        {
            source.Stop();

            if (isTimeForRewardedAds)
            {
                ShowRewardedAdv();
            }
            else
            {
                ShowAdv();
            }
        }
    }

    public void SetIsTimeForRewardedAds(bool isTrue)
    {
        isTimeForRewardedAds = isTrue;
    }

    // Call via button to unlock video
    public void StartUnlockButton()
    {
        source.Stop();
        UnlockButtonsExtern();
    }

    // Called after watched an ad
    public void UnlockRow()
    {
        block.SetActive(false);
    }

    public void ResetBlock(bool showBlocks)
    {
        block.SetActive(showBlocks);
    }

    public bool isMobile()
    {
#if !UNITY_EDITOR && UNITY_WEBGL
        return IsMobile();
#endif
        return false;
    }
}
