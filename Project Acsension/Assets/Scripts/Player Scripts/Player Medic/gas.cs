using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class gas : MonoBehaviour
{
    public float currentGasDuration;
    public float maxGasDuration;
    public int gasDamage;

    private void Start()
    {
        currentGasDuration = maxGasDuration;
        StartCoroutine(lingerEffect());
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Enemy")
        {
            var enemyHealth = GetComponent<EnemyHealth>();
            if(enemyHealth != null)
            {
                enemyHealth.TakeDamage(gasDamage);
            }
        }
    }

    private IEnumerator lingerEffect()
    {

        yield return new WaitForSeconds(currentGasDuration);
        if(currentGasDuration <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
