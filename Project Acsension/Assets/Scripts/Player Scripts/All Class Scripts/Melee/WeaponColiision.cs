using UnityEngine;

public class WeaponColiision : MonoBehaviour
{
    private float damage;
    private Melee meleeRef;

    public void GetValues(Melee melee, int damage)
    {
        this.meleeRef = melee;
        this.damage = damage;
    }

    public void EndSwing()
    {
        meleeRef.SwingEnd(); //references the melee script and ends the swing
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.TryGetComponent<EnemyHealth>(out EnemyHealth health);
        
        if (health != null)
        {
            health.TakeDamage(5);
        }
    }

}
