using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButtonController : MonoBehaviour {

	public int ID;
    public string Name;
    public Text displayTXT;
    public Button shopBTN;

    public ShopController Owner;
    public void InitializeButton(int id, string name)
    {
        ID = id;
        Name = name;

        displayTXT.text = name;

    }

    public void Selected()
    {
       // Owner.OnItemSelected(ID);
    }
}
