using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Brick : MonoBehaviour
{
    public UnityEvent<int> onDestroyed;
    
    public int PointValue;

    private Color myYellow = new Color(0.9f, 0.9f, 0.7f, 1.0f);
    private Color myGreen = new Color(0.8f, 1.0f, 0.9f, 1.0f);
    private Color myPurple = new Color(0.9f, 0.8f, 1.0f, 1.0f);

    void Start()
    {
        var renderer = GetComponentInChildren<Renderer>();

        MaterialPropertyBlock block = new MaterialPropertyBlock();
        switch (PointValue)
        {
            case 1 :
                block.SetColor("_BaseColor", myPurple);
                break;
            case 2:
                block.SetColor("_BaseColor", myGreen);
                break;
            case 5:
                block.SetColor("_BaseColor", myYellow);
                break;
            default:
                block.SetColor("_BaseColor", Color.red);
                break;
        }
        renderer.SetPropertyBlock(block);
    }

    private void OnCollisionEnter(Collision other)
    {
        onDestroyed.Invoke(PointValue);
        
        //slight delay to be sure the ball have time to bounce
        Destroy(gameObject, 0.2f);
    }
}
