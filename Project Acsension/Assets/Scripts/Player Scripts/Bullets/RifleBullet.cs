using UnityEngine;

public class RifleBullet : MonoBehaviour
{
    float minPierceCounter;
    float maxPierceCounter = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        minPierceCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            var enemyHealth = GetComponent<EnemyHealth>();

            minPierceCounter += 1;

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(4);
            }
        }
        else
        {
            Destroy(this.gameObject);
        }

        if (minPierceCounter == maxPierceCounter)
        {
            Destroy(this.gameObject);
        }
    }
}
