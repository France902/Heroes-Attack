using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityCollider : MonoBehaviour
{
    // Riferimento allo script principale del personaggio
    private GravityCharacter character;

    void Start()
    {
        
        // Cerca lo script GravityCharacter nell'oggetto padre
        character = GetComponentInParent<GravityCharacter>();
    }

    // Quando il trigger entra in contatto con qualcosa
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        // Controlla se l'oggetto toccato ha il tag "Ground"
        if (collision.CompareTag("Ground"))
        {
            character.SetGrounded(true);
        }
    }

    // Quando il trigger si stacca dal terreno
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            character.SetGrounded(false);
        }
    }
}