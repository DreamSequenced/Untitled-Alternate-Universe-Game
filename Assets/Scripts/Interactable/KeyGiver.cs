using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyGiver : Interactable
{
    [SerializeField]
    private Key key;

    public override void OnInteract()
    {
        Inventory.Instance.AddKey(key);
        Destroy(this);
    }

    private void OnMouseOver()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            OnInteract();
        }
    }
}
