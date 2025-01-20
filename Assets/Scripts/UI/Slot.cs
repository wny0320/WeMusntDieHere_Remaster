using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Image image;
    public Item item;

    public void Awake()
    {
        image = GetComponent<Image>();
    }
    public void Update()
    {
        if(item != null)
            image.sprite = item.itemSprite;
        else
            image.sprite = null;
    }
    public void AssginItem(Item _item)
    {
        item = _item;
    }
}
