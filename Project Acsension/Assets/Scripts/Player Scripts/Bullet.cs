using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Bullet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Quaternion bulletRotation = Quaternion.Euler(0f, 0f, 90f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Enemy")
        {
            var enemyHealth = collision.GetComponent<EnemyHealth>();

            if(collision != null)
            {
                enemyHealth.TakeDamage(1);
            }
        }

        if (collision.tag != "Bullet")
        {
            Destroy(gameObject);
        }
    }
}
