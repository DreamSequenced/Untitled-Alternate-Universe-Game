using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject menu;

    private void Update()
    {
        OnEscapeButton();
    }

    public void OnEscapeButton()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            OnPause();
        }
    }

    public void OnPause()
    {
        menu.SetActive(!menu.activeInHierarchy);

        Time.timeScale = menu.activeInHierarchy ? 0f : 1f;
    }
}
