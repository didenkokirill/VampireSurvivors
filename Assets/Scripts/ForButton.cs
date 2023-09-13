using UnityEngine;
using UnityEngine.SceneManagement;

public class ForButton : MonoBehaviour
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

    public void Restart()
    {
        MenuManager.Instance.RemoveFromPause();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void SecondLife()
    {
        MenuManager.Instance.CloseGameOverMenu();
        MenuManager.Instance.GiveSecondLive();
    }
    public void GoShop()
    {
        MenuManager.Instance.OpenShopMenu();
    }

    [SerializeField] private ShopSlot shopSlot;

    public void Buy()
    {
        shopSlot.ChangeButtonTo(shopSlot.GiveButtonForSell());
    }
    public void Sell()
    {
        shopSlot.ChangeButtonTo(shopSlot.GiveButtonForEquip());
        SaveManager.Instance.PlayerInfo.slot1 = shopSlot.GiveSlotNumber();
    }
}
