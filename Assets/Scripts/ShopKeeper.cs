using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper : MonoBehaviour
{
    public static ShopKeeper Instance;

    private void Awake() 
    {
        Instance = this;
        UpdateStore();
    }

    [SerializeField] private List<ShopSlot> slots = new List<ShopSlot>();
    [SerializeField] private int[] bought = SaveManager.Instance.GetBought();
    [SerializeField] private int equiped = SaveManager.Instance.GetEquiped();

    public void ChangeEquiped(int newEquiped, int previusEquiped = 0)
    {
        ShopSlot unEquipeShopSlot = slots[previusEquiped];
        unEquipeShopSlot.ChangeButtonTo(unEquipeShopSlot.GiveButtonForEquip());

        var ImageToEquipe = slots[newEquiped].GetImage();
        PlayerController.Instance.SetSprite(ImageToEquipe.sprite);

        SaveManager.Instance.Save();
    }

    public void UpdateStore()
    {
        for(int i = 0; i < bought.Length; i++)
        {
            if (bought[i] == 1)
            {
                slots[i].ChangeButtonTo(slots[i].GiveButtonForEquip());
            }
        }
        slots[equiped].ChangeButtonTo(slots[equiped].GiveButtonForEquiped());
    }
}
