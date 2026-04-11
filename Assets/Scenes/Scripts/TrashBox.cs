using UnityEngine;

public class MoveStraight : MonoBehaviour
{
    public float speed = 1f;

    void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }
}
