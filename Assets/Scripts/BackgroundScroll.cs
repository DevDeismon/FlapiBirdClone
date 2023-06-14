using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [SerializeField] private float speed;
    private MeshRenderer _meshBg;
    void Start()
    {
        _meshBg=GetComponent<MeshRenderer>();
    }

    void Update()
    {
        _meshBg.material.mainTextureOffset += new Vector2(speed * Time.deltaTime,0);
    }
}
