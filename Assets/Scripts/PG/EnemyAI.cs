using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    float speed = 1f;
    Tower target;
    
    void Start()
    {
        target = GameObject.FindObjectOfType<Tower>();
    }

    
    void Update()
    {
        if (target != null)
        {

            float distanceX = Mathf.Abs(transform.position.x - target.transform.position.x);

            if (distanceX > 2f)
            {
                float directionX = Mathf.Sign(target.transform.position.x - transform.position.x);

                Vector2 movement = new Vector2(directionX * speed * Time.deltaTime, 0);

               
                transform.Translate(movement);
            }
        }
        }
}
