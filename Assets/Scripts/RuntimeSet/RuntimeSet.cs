using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class RuntimeSet<T> : ScriptableObject
{
    public List<T> Items = new List<T>();
    public class ItemEvent : UnityEvent<T> { }
    public ItemEvent OnAddItem = new ItemEvent();
    public ItemEvent OnRemoveItem = new ItemEvent();

    public virtual void AddItemRange(List<T> items)
    {
        foreach(T item in Items)
            AddItem(item);
    }

    public virtual void AddItem(T item)
    {
        if (!Items.Contains(item))
        {
            Items.Add(item);
            OnAddItem.Invoke(item);
        }
    }

    public virtual void RemoveItem(T item)
    {
        if (Items.Contains(item))
        {
            Items.Remove(item);
            OnRemoveItem.Invoke(item);
        }
    }
}
