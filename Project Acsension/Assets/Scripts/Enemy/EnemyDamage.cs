using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
   // public PlayerHealth playerHP; //player health script
    bool isAttacking; //attacking animation bool
    bool isChasing;
    public Animator anim; //animator, duh
    public int damage; //how much dmg enemy will deal
    public PlayerHealth playerHP;

    void Start()
    {
       // playerHealth = GetComponent<PlayerHealth>();
    }

    private void OnCollisionEnter(Collision collision) //upon collision
    {
        if (collision.gameObject.tag == "Player")
        {
            // var playerHealth = GetComponent<PlayerHealth>(); //player's health script 


            if (collision != null)
            {
                anim.SetBool("isChasing", false);
                anim.SetBool("isAttacking", true); //attacking animation on
                playerHP.TakeDamage(damage); //player will receive this much dmg 
            }
            else
            {
                
                anim.SetBool("isAttacking", false); //attacking animation off
            }

        }
       

    }

}
