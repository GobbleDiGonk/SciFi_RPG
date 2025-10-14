using System.Security.Principal;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private float timer = 5;
    private float bulletTime = 1;

    public GameObject enemyBullet;
    public Transform spawnPoint;
    public float bulletSpeed;
    public Transform player;

    public float sightRange;
    public LayerMask playerLayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerDetect();
    }

    void ShootAtPlayer()
    {
        bulletTime -= Time.deltaTime;
        if (bulletTime > 0) return;
        bulletTime = timer;

        GameObject bulletObj = Instantiate(enemyBullet, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
        Rigidbody bulletRig = bulletObj.GetComponent<Rigidbody>();
        bulletRig.AddForce(bulletRig.transform.forward * bulletSpeed);
        Destroy(bulletObj, 5f);
    }
    
    void PlayerDetect()
    {
        Debug.DrawRay(transform.position, transform.forward * sightRange, Color.green);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, sightRange, playerLayer))
        {
            Debug.Log("Something Found");
            if (hit.collider != null) //if found something
            {
                ShootAtPlayer();
            }
        }

    }
}
