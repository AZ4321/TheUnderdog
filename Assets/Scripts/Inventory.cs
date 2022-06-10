using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    #region Singleton

    public static Inventory instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }
        instance = this;
    }

    #endregion


    public delegate void OnItemChanged(); //Different method, same event

    public OnItemChanged onItemChangedCallBack;


    public List<Item> items = new List<Item>();

    public int space = 24;

    public bool Add (Item item)
    {
        if (!item.isDefaultItem)
        {   
            if (items.Count >= space)
            {
                Debug.Log("Not enough room fella");
                return false;
            }

            items.Add(item);

            if (onItemChangedCallBack != null) //Make sure to do a check if the value has nothing otherwise errors
            onItemChangedCallBack.Invoke(); //Triggering event so UI updates
        }

        return true;
    }

    public void Remove (Item item)
    {
        items.Remove(item);

        if (onItemChangedCallBack != null) 
            onItemChangedCallBack.Invoke();
    }






}
