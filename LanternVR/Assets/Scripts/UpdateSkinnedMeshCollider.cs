﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateSkinnedMeshCollider : MonoBehaviour {

    SkinnedMeshRenderer meshRenderer;
    MeshCollider collider;
	// Use this for initialization
	void Start () {
        meshRenderer = GetComponent<SkinnedMeshRenderer>();
        collider = GetComponent<MeshCollider>();
	}
	
	// Update is called once per frame
	void Update () {
        Mesh colliderMesh = new Mesh();
        meshRenderer.BakeMesh(colliderMesh);
        collider.sharedMesh = null;
        collider.sharedMesh = colliderMesh;
	}


}
