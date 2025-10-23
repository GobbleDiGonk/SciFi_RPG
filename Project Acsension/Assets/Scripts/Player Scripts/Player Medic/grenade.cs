using UnityEngine;

public class grenade : MonoBehaviour
{
    public GameObject gas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            Instantiate(gas, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if(collision.gameObject.tag == "Enemy")
        {
            Instantiate(gas, transform.position , Quaternion.identity);
            var enemyHealth = GetComponent<EnemyHealth>();
            enemyHealth.TakeDamage(1);
            Destroy(gameObject);
        }
    }
}
