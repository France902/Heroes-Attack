using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegSxBehaviour : MonoBehaviour
{

    [Header("Sprite della gamba SX")]
    public GameObject legIdle;
    public GameObject legWalk;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void ShowLegWalking()
    {
        legIdle.SetActive(false);
        legWalk.SetActive(true);
    }

    // Chiamato dall'Animation Event ? torna alla gamba attaccata
    public void ShowLegIdle()
    {
        legIdle.SetActive(true);
        legWalk.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
