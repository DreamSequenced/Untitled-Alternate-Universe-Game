﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RestrictCameraY : MonoBehaviour
{
    private Transform target;
    public Tilemap map;

    private Vector3 bottomLeftLimit;
    private Vector3 topRightLimit;

    private float halfHeight;
    private float halfWidth;

    void Start()
    {
        halfHeight = Camera.main.orthographicSize;
        halfWidth = halfHeight * Camera.main.aspect;

        bottomLeftLimit = map.localBounds.min + new Vector3(halfWidth, halfHeight, 0f);
        topRightLimit = map.localBounds.max + new Vector3(-halfWidth, -halfHeight, 0f);

        target = PlayerController.Instance.transform;
        target.GetComponent<PlayerController>().SetBounds(map.localBounds.min, map.localBounds.max);
    }

    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(target.position.x, bottomLeftLimit.x, topRightLimit.x),
            transform.position.y, -10f);
    }
}
