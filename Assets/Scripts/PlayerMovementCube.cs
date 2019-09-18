﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementCube : MonoBehaviour
{

    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed, 0f, Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed);
    }
}
