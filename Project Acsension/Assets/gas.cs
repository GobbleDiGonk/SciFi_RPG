using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class gas : MonoBehaviour
{
    public float gasDuration = 6;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void dealDamage()
    {
       var enemy = GetComponent<EnemyHealth>();

        enemy.TakeDamage(1);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(gameObject.tag == "Enemy")
        {
            dealDamage();
        }
    }

    private IEnumerator gasTimer()
    {
        yield return new WaitForSeconds(gasDuration);
        Destroy(gameObject);
    }
}
