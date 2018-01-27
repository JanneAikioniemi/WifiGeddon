using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDB 
{
    public class Item
    {
        protected float price;

        public virtual void SetPrice(float p)
        {
            price = p;
        }
    }

    public class FoodItem : Item
    {

    }

    

    public class SabotageItems : Item
    {

    }


}
