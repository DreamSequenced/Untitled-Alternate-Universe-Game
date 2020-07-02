using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeySlot : MonoBehaviour
{
    [SerializeField]
    private Image keyImage;

    private void Start()
    {
        keyImage = GetComponent<Image>();
    }

    public void UpdateSprite(Sprite image)
    {
        keyImage.sprite = image;
    }
}
