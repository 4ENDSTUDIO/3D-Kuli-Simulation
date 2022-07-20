using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("More than one instance of inventory");
            return;
        }
        instance = this;
    }
    #endregion

    public delegate void OnItemChanged();
    // delegate void Delegasi adalah wadah untuk fungsi yang dapat digunakan sebagai variabel. Delegasi membantu dalam membuat kode modular dan efisien. Ini berfungsi seperti layanan berbasis langganan, di mana metode yang diteruskan dipanggil saat berlangganan dan sebaliknya.
    public OnItemChanged onItemChangedCallBack;

    private int space = 20;
    public List<Item> items = new List<Item>();

    public bool Add(Item item)
    {
        if(item.isDefaultItem)
        {
            if(items.Count >= space)
            {
                GameMessagee.instance.Send("Inventory Full");
                Debug.Log("Not Enaogh room");
                return false;
            }
            GameMessagee.instance.Send("+" + item.name);
            items.Add(item);
            if(onItemChangedCallBack  != null)
            {
                onItemChangedCallBack.Invoke();
            }
        }
        return true;
    }

    public void Remove(Item item)
       
    {

        items.Remove(item);
        if(onItemChangedCallBack != null)
        {
            onItemChangedCallBack.Invoke();
        }
    }
}
