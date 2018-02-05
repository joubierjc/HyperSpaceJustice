﻿using UnityEngine;

public class OffsetScroller : MonoBehaviour {

    public float scrollSpeed;
    private Vector2 savedOffset;

    private Renderer rend;

    void Start() {
        rend = GetComponent<Renderer>();
        savedOffset = rend.sharedMaterial.GetTextureOffset("_MainTex");
    }

    void Update() {
        float x = Mathf.Repeat(Time.time * scrollSpeed, 1);
        Vector2 offset = new Vector2(x, savedOffset.y);
        rend.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }

    void OnDisable() {
        rend.sharedMaterial.SetTextureOffset("_MainTex", savedOffset);
    }
}