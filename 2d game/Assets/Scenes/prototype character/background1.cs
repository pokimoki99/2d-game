using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background1 : MonoBehaviour
{
    public float Speed;
    private Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        _renderer.material.mainTextureOffset = new Vector2(Time.time * Speed, 0);
    }
}
