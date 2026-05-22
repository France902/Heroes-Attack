using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityCharacter : MonoBehaviour
{
    public float gravityForce = 9.81f; 
    public GravityCollider gc;

    private bool isGrounded = false;

    void Start()
    {

    }

    void Update()
    {
        Debug.Log(isGrounded);
        // Se NON è sul terreno, applica la gravità verso il basso
        if (!isGrounded)
        {
            transform.Translate(Vector3.down * gravityForce * Time.deltaTime);
        }

        /* Qui puoi gestire il movimento orizzontale standard con 'speed'
        float moveX = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * moveX * speed * Time.deltaTime);
        */
    }

    // Funzione pubblica che permette al GravityCollider di cambiare lo stato
    public void SetGrounded(bool grounded)
    {
        isGrounded = grounded;
    }
}