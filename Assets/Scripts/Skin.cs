using UnityEngine;
using UnityEngine.UI;

public class Skin
{
    public string number;
    public int prise;
    public Image image;
}

public class ShopSlot : MonoBehaviour
{
    [SerializeField] private Skin skin;
    [SerializeField] private Button buttonForBuy;
    [SerializeField] private Button buttonForSell;

}

