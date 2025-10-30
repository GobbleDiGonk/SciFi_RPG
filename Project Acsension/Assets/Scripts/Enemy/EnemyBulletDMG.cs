using UnityEngine;

public class EnemyBulletDMG : MonoBehaviour
{
   PlayerHealth playerHP;
    public int damage;

    private void Start()
    {
        playerHP = GetComponent<PlayerHealth>();
    }
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //var playerHealth = GetComponent<PlayerHealth>();

            if (collision != null)
            {
                playerHP.TakeDamage(damage);
               
            }
        }

    }
}
