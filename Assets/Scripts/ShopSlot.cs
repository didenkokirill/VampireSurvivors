using UnityEngine;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour
{
    [SerializeField] private int number;
    [SerializeField] private Image image;
    [SerializeField] private Button buttonForBuy, buttonForEquip, buttonForEquiped;

    public int GiveSlotNumber()
    {
        return number;
    }

    public Image GetImage()
    {
        return image;
    }

    public Button GiveButtonForBuy()
    {
        return buttonForBuy;
    }
    public Button GiveButtonForEquip()
    {
        return buttonForEquip;
    }
    public Button GiveButtonForEquiped()
    {
        return buttonForEquiped;
    }

    public void ChangeButtonTo(Button activeButton)
    {
        buttonForBuy.gameObject.SetActive(false);
        buttonForEquip.gameObject.SetActive(false);
        buttonForEquiped.gameObject.SetActive(false); 

        activeButton.gameObject.SetActive(true);
    }
}
