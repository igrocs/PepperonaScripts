﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class MorcegoGFX : MonoBehaviour {
    public AIPath aiPath;
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-0.31808f, 0.338655f, 1f);
        }
        else if (aiPath.desiredVelocity.x <= -0.01f) {
            transform.localScale = new Vector3(0.31808f, 0.338655f, 1f);
        }
        
    }
}
