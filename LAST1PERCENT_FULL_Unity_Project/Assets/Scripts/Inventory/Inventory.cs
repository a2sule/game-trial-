using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class InventoryItem
{
    public string id;
    public int amount;
    public InventoryItem(string id,int amount){this.id=id;this.amount=amount;}
}

public class Inventory : MonoBehaviour
{
    public List<InventoryItem> items = new List<InventoryItem>();

    public void Add(string id,int amount)
    {
        if (amount <= 0) return;
        InventoryItem item = items.Find(x=>x.id==id);
        if(item==null) items.Add(new InventoryItem(id,amount));
        else item.amount += amount;
    }

    public bool Remove(string id,int amount)
    {
        InventoryItem item=items.Find(x=>x.id==id);
        if(item==null || item.amount<amount) return false;
        item.amount-=amount;
        if(item.amount<=0) items.Remove(item);
        return true;
    }

    public int Count(string id)
    {
        InventoryItem item=items.Find(x=>x.id==id);
        return item==null?0:item.amount;
    }
}
