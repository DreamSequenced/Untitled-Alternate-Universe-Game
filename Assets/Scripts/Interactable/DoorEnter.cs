using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEnter : MonoBehaviour
{
    [SerializeField]
    private Vector2 enterPosition;
    [SerializeField]
    private string doorToEnter;

    private void Start()
    {

        if (PortalManager.Instance.currentDoor != null &&
            doorToEnter == PortalManager.Instance.currentDoor)
        {
            PlayerController.Instance.transform.position = enterPosition;
        }
    }
}
