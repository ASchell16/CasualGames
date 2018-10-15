using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[Serializable]
public enum ItemCategory
    {
         Health,
         Stamina,
         Magic
    }
[Serializable]
public class Models
{
    public int ID;
    public double Cost;
    public string Name;
    public ItemCategory Category;
}

 
