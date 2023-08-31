using UnityEngine;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour
{
    [SerializeField] private int number;
    [SerializeField] private Button buttonForBuy, buttonForSell, buttonForEquip;

    public int GiveSlotNumber()
    {
        return number;
    }

    public Button GiveButtonForBuy()
    {
        return buttonForBuy;
    }
    public Button GiveButtonForSell()
    {
        return buttonForSell;
    }
    public Button GiveButtonForEquip()
    {
        return buttonForEquip;
    }

    public void ChangeButtonTo(Button activeButton)
    {
        Debug.Log("changebutton");
        buttonForBuy.enabled = false;
        buttonForSell.enabled = false;
        buttonForEquip.enabled = false;

        activeButton.enabled = true;
    }
}
