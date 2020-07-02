using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public static HUD Instance;

    [SerializeField]
    private List<KeySlot> keySlots;

    private void Start()
    {
        if (Instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        // To-do improve
        GetComponent<Canvas>().worldCamera = FindObjectOfType<Camera>();
    }

    public void UpdateHUD()
    {
        List<Key> keys = Inventory.Instance.keys;

        for(int i = 0; i < keys.Count; i++)
        {
            if(keys[i] != null)
            {
                keySlots[i].UpdateSprite(keys[i].keyImage);
            }
        }
    }
}
