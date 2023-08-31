using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper : MonoBehaviour
{
    [SerializeField] private List<ShopSlot> slots = new List<ShopSlot>();



    public void UpdateStore()
    {
        foreach (ShopSlot slot in slots)
        {
            
        }
    }
}
