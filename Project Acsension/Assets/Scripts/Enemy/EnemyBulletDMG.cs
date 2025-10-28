using UnityEngine;

public class EnemyBulletDMG : MonoBehaviour
{
    public PlayerHealth playerHP;

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            //var playerHealth = GetComponent<PlayerHealth>();

            if (collision != null)
            {
                playerHP.TakeDamage(2);
            }
        }
        
    }

}
