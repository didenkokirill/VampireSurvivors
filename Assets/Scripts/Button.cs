using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private GameObject pistol, shotgun, rocketLauncer;

    public void OnClickPistol()
    {
        pistol.SetActive(true);
        shotgun.SetActive(false);
        rocketLauncer.SetActive(false);
        MenuManager.Instance.CloseUpdateMenu();
    }
    public void OnClickShotgun()
    {
        pistol.SetActive(false);
        shotgun.SetActive(true);
        rocketLauncer.SetActive(false);
        MenuManager.Instance.CloseUpdateMenu();
    }
    public void OnClickRockenLauncher()
    {
        pistol.SetActive(false);
        shotgun.SetActive(false);
        rocketLauncer.SetActive(true);
        MenuManager.Instance.CloseUpdateMenu();
    }
}
