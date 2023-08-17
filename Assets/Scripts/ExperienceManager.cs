using TMPro;
using UnityEngine;

public class ExperienceManager : MonoBehaviour
{
    public static ExperienceManager Instance;

    [SerializeField] private GameObject expProjectile;
    [SerializeField] private int value;
    [SerializeField] private int currentExp, maxExp;
    [SerializeField] private int currentLevel, maxLevel;

    [SerializeField] private TMP_Text experenceText, levelText;

    private void Awake() => Instance = this;

    void Start()
    {
        experenceText.text = $"Exp: {currentExp}";
        levelText.text = $"Lvl: {currentLevel}";
    }

    public void DropExp(Vector3 position)
    {
        GameObject newExp = Instantiate(expProjectile, position, Quaternion.identity);
        newExp.GetComponent<Experience>().value = value;

        //for (int i = 0; i < amount; i++)            //Alternative
        //{
        //    GameObject newExp = Instantiate(expProjectile, position, Quaternion.identity);
        //}
    }

    public void AddExp(int amount)
    {
        if (currentExp >= maxExp)
        {
            currentExp = 0;
            AddLevel();
        }

        currentExp += amount;
        experenceText.text = $"Exp: {currentExp}";
    }

    private void AddLevel()
    {
        if (currentLevel < maxLevel)
        {
            currentLevel++;
        }
        levelText.text = $"Lvl: {currentLevel}";
    }
}
