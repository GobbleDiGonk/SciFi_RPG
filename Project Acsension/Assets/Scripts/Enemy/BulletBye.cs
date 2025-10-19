using UnityEngine;

public class BulletBye : MonoBehaviour
{
    void OnTriggerEnter(UnityEngine.Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }

    }

}
