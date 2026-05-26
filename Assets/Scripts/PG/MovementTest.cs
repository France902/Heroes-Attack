using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTest : MonoBehaviour
{
    private Animator animator;
    private bool isWalking = false;

    void Start()
    {
        // Cerca l'oggetto nella scena tramite il nome
        GameObject targetObject = GameObject.Find("PG");

        if (targetObject != null)
        {
            // Recupera il componente Animator
            animator = targetObject.GetComponent<Animator>();

            if (animator != null)
            {
                // Avvia il ciclo continuo che cambia lo stato ogni 0.5 secondi
                StartCoroutine(ToggleWalkingRoutine());
            }
            
        }
        
    }

    // Coroutine che gira in background
    IEnumerator ToggleWalkingRoutine()
    {
        // "while(true)" crea un ciclo infinito che dura per tutta la vita dello script
        while (true)
        {
            // Inverte il valore booleano (se è true diventa false, se è false diventa true)
            isWalking = !isWalking;

            // Applica il nuovo valore all'Animator
            animator.SetBool("walking", isWalking);

            // Mette in pausa la Coroutine per esattamente 0.5 secondi prima di rieseguire il ciclo
            yield return new WaitForSeconds(1);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
