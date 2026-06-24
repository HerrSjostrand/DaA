using UnityEngine;

public class Trash : MonoBehaviour
{
    public float speed;
    public Transform _transform;
    void Update()
    {
        _transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime);
    }
}
