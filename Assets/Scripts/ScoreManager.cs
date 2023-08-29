using System.Diagnostics;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo
{
    public int bestScore;
}

public class ScoreManager : MonoBehaviour
{
    [DllImport("__Internal")] private static extern void SaveExtern(string date);
    [DllImport("__Internal")] private static extern void LoadExtern();

    public PlayerInfo PlayerInfo;

    public static ScoreManager Instance;

    

    [SerializeField] private int score;
    [SerializeField] private int bestScore;
    [SerializeField] private TMP_Text scoreText, bestScoreText;
    private string scoreTextBase, bestScoreTextBase;

    private void Awake()
    {
        Instance = this;

        bestScore = GetBestScore();
        scoreTextBase = scoreText.text;
        bestScoreTextBase = bestScoreText.text;
    }

    public void AddScore(int amount)
    {
        score += amount;
    }
    public int GetBestScore()
    {
        return PlayerInfo.bestScore;
    }

    public void ChangeBestScore()
    {
        if (score > bestScore)
        {
            bestScore = score;
            PlayerInfo.bestScore = bestScore;
            Save();
        }
    }
    public void UpdateScoresTexts()
    {
        scoreText.text = scoreTextBase + score.ToString();
        bestScoreText.text = bestScoreTextBase + bestScore.ToString();
    }

    private void Save()
    {
        string jsonString = JsonUtility.ToJson(PlayerInfo);
#if !UNITY_EDITOR && UNITY_WEBGL
        SaveExtern(jsonString);
#endif
    }
}
