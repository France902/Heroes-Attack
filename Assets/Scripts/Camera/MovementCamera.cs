using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCamera : MonoBehaviour
{

    public float camVel = 5.0f;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMov = Input.GetAxis("Horizontal");

        Vector2 direction = new Vector2(horizontalMov, 0.0f);

        transform.Translate(direction * camVel * Time.deltaTime);
    }
}
