﻿using UnityEngine;
using System.Collections;

public class staticController : MonoBehaviour {

    public static float speed = 100; // controls speed along the Z axis of all objects.

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (speed > 150) speed = 150; //speed cap
        if (speed < 0) speed = 0;
	}
}
