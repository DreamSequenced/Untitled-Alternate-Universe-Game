using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    public int maxKeys = 3;

    private void Start()
    {
        Instance = this;

        keys = new List<Key>();
    }

    public List<Key> keys { get; set; }

    public bool AddKey(Key key)
    {
        if(keys.Count >= 3)
        {
            return false;
        }

        if(!keys.Contains(key))
        {
            keys.Add(key);
        }

        HUD.Instance.UpdateHUD();

        return true;
    }

    public bool CheckForKey(Key requiredKey)
    {
        if(keys.Contains(requiredKey))
        {
            HUD.Instance.UpdateHUD();
            return true;
        }
        else
        {
            HUD.Instance.UpdateHUD();
            return false;
        }
    }
}
