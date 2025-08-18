using UnityEngine;

public class MonstersGlasses : MonoBehaviour
{
    public float distance = 5f;
    public float speed = 2f;
    Vector3 startPos;
    float offset;

    void Start()
    {
        startPos = transform.position;
        offset = Random.value * 10f;
    }

    void Update()
    {
        float x = Mathf.PingPong((Time.time + offset) * speed, distance) - distance / 2f;
        transform.position = startPos + new Vector3 (x, 0, 0);

    }

}
