using TMPro;
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
        MenuManager.Instance.CloseGameOverMenu();
    }
    public void CloseShop()
    {
        Restart();
    }

    [SerializeField] private ShopSlot shopSlot;
    [SerializeField] private TMP_Text equipButtonText;
 
    public void Buy()
    {
        shopSlot.ChangeButtonTo(shopSlot.GiveButtonForEquip());
        SaveManager.Instance.AddBoughtSkin(shopSlot.GiveSlotNumber());
    }
    public void Equip()
    {
        shopSlot.ChangeButtonTo(shopSlot.GiveButtonForEquiped());

        int previusEquiped = SaveManager.Instance.PlayerInfo.equiped;
        SaveManager.Instance.PlayerInfo.equiped = shopSlot.GiveSlotNumber();
        ShopKeeper.Instance.ChangeEquiped(shopSlot.GiveSlotNumber(), previusEquiped);
    }
}
