using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    private MeshRenderer meshrenderer;
    public float animationspeed = 1f;
    // Start is called before the first frame update
    private void Awake()
    {
        meshrenderer = GetComponent<MeshRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
        meshrenderer.material.mainTextureOffset += new Vector2(animationspeed * Time.deltaTime,0);
    }
}
