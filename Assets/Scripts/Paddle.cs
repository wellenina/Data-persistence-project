using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float Speed = 2.0f;
    public float MaxMovement = 2.0f;
    private MainManager mainManagerScript;
    
    // Start is called before the first frame update
    void Start()
    {
        mainManagerScript = GameObject.Find("MainManager").GetComponent<MainManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float input = Input.GetAxis("Horizontal");

        Vector3 pos = transform.position;
        pos.x += input * Speed * Time.deltaTime;

        if (pos.x > MaxMovement)
            pos.x = MaxMovement;
        else if (pos.x < -MaxMovement)
            pos.x = -MaxMovement;

        transform.position = pos;
    }

    void OnCollisionEnter(Collision collision)
    {
        int bricksCount = FindObjectsOfType<Brick>().Length;
        if (bricksCount == 0)
        {
            mainManagerScript.InstantiateBricks();
        }
    }
}
