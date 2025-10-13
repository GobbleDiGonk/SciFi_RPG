using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 20;
    public int currentHealth;

    public healthBar healthBar;

    public Gradient gradient;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
    }

    public void SelfHarm()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(5);
            Debug.Log("Is taking damage");
        }
    }

    // Update is called once per frame
    void Update()
    {
        SelfHarm();
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.setHealth(currentHealth);

        if(currentHealth == 0)
        {
            Destroy(gameObject);
        }
    }
}
