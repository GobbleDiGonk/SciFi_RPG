using UnityEngine;

public class ShotgunFleecette : MonoBehaviour
{
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

            if (collision != null)
            {
                enemyHealth.TakeDamage(4);
            }
        }

        if (collision.tag != "Bullet")
        {
            Destroy(gameObject);
        }
    }
}
