using System.Collections;
using TMPro;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    [SerializeField] private GameObject updateMenu;
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
        onPause = false;
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
}
