using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

[System.Serializable]
public class PlayerInfo
{
    public int bestScore;
    public int slot1, slot2;
}

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { get; private set; }

    public PlayerInfo PlayerInfo;

    [DllImport("__Internal")] private static extern void SaveExtern(string date);
    [DllImport("__Internal")] private static extern void LoadExtern();

    [SerializeField] private string dateToUnlock;
    [SerializeField] private int score, bestScore;
    [SerializeField] private TMP_Text scoreText, bestScoreText;
    private string scoreTextBase, bestScoreTextBase;

    private bool isTime;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SetIsTime();

#if !UNITY_EDITOR && UNITY_WEBGL
        LoadExtern();
#endif
    }

    // called from .jslib
    public void SetPlayerInfo(string value)
    {
        if (value == string.Empty)
        {
            return;
        }

        PlayerInfo = JsonUtility.FromJson<PlayerInfo>(value);
    }

    public void AddScore(int amount)
    {
        score += amount;
    }
    public void UpdateScoresTexts()
    {
        scoreText.text = scoreTextBase + score.ToString();
        bestScoreText.text = bestScoreTextBase + bestScore.ToString();
    }

    public void SaveBestScore()
    {
        PlayerInfo.bestScore = bestScore;
        Save();
    }

    public int GetBestScore()
    {
        return PlayerInfo.bestScore;
    }

    public void SaveSkinCondition(int num)
    {
        
    }

    public void ClearData()
    {
        PlayerInfo.bestScore = 0;
        Save();
    }

    private void Save()
    {
        string jsonString = JsonUtility.ToJson(PlayerInfo);
#if !UNITY_EDITOR && UNITY_WEBGL
        SaveExtern(jsonString);
#endif
    }

    private void SetIsTime()
    {
        isTime = DateTime.Now >= DateTime.Parse(dateToUnlock); // time to show rewarded ads if now IS MORE than Date To Unlock
        GameManager.Instance.SetIsTimeForRewardedAds(isTime);
    }
}
