using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    public List<Models> shopItems = new List<Models>();
    public GameObject shopButtonTemplate;
    public GameObject contentPanel;

    void Start()
    {
        shopItems = ApiHelper.GetShopItems();
        Populate();
    }

    public void Populate()
    {
        GameObject button;
        foreach (var item in shopItems)
        {
            button = Instantiate(shopButtonTemplate, contentPanel.transform);
            ItemButtonController controller = button.GetComponent<ItemButtonController>();
            controller.InitializeButton(item.ID, item.Name);
            controller.Owner = this;
        }
    }
    public void Clear()
    {
        var children = GetComponentsInChildren<ItemButtonController>();

        foreach (var button in children)
            Destroy(button);
    }

    public void OnItemSelected(int id)
    {
        Models selectedItem = shopItems.Find(i => i.ID == id);
        Debug.Log(selectedItem.Name + " : " + selectedItem.Cost);
    }
    //public void Show()
    //{
    //    shopButtonTemplate.SetActive(true);
    //}

    //public void Hide()
    //{
    //    shopButtonTemplate.SetActive(false);
    //}

}

