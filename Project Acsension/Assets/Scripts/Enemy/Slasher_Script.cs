using UnityEngine;

public class Slasher_Script : MonoBehaviour
{
    public Transform eyeball; //empty object in enemy to draw raycast
    public float sightRange; //how far can the enemy see
    public LayerMask playerLayer; //detect player, requires layer named player
    public Rigidbody rb; //you know what this is

    private Transform player; //explained in Start()
    bool isChasing; //animation bool to allow chasing
    public Animator anim; //animator

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>(); //grab the rb component
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); //player REQUIRES TAG NAMED PLAYER
    }

    // Update is called once per frame
    void Update()
    {
        PlayerDetect(); //allows enemy to detect
    }

    void PlayerDetect()
    {

        Debug.DrawRay(eyeball.transform.position, eyeball.transform.forward * sightRange, Color.green);
        RaycastHit hit;
        if (Physics.Raycast(eyeball.transform.position, eyeball.transform.forward, out hit, sightRange, playerLayer))
        {
            Debug.Log("Something Found");
            if (hit.collider != null) //if found something
            {
                transform.position = Vector3.MoveTowards(this.transform.position, player.position, 3 * Time.deltaTime); //enemy start chasing
                anim.SetBool("isChasing", true); //allow chasing animation
            }
         

        }
        else
        {
            anim.SetBool("isChasing", false); //return to idle animation
            rb.linearVelocity = Vector3.zero; //stationary in their position / will not return to original position if moved

        }

    }
}
    
