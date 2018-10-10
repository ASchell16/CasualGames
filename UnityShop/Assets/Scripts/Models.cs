using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public enum ItemCategory
    {
         Health,
         Stamina,
         Magic
    }
public class Models // possibly Item
{
    public int ID;
    public double Cost;
    public string Name;
    public ItemCategory Category;
}

 
