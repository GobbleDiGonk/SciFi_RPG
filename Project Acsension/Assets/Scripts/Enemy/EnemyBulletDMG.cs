using UnityEngine;

public class EnemyBulletDMG : MonoBehaviour
{
    public int damage;
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            var playerHP = GetComponent<PlayerHealth>();

            if (playerHP != null)
            {
                playerHP.TakeDamage(damage);
               
            }
        }

    }
}
