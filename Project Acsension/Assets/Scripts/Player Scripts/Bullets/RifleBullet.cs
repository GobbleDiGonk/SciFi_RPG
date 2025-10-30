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

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Enemy")
        {
            var enemyHealth = collision.GetComponent<EnemyHealth>();

            minPierceCounter += 1;

            if (collision != null)
            {
                enemyHealth.TakeDamage(4);
            }
        }
        else
        {
            Destroy(this.gameObject);
        }
        if (collision.tag == "Boss")
        {
            var bossHealth = collision.GetComponent<BossHPScript>();

            minPierceCounter += 1;

            if (collision != null)
            {
                bossHealth.TakeDamage(4);
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
