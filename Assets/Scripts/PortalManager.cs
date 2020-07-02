using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    public static PortalManager Instance;

    public string currentDoor = "";

    private void Start()
    {
        Instance = this;
    }
}
