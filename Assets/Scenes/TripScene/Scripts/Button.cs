using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject button;
    public Transform player;
    public Transform enemy;
    public float interactionDistance = 2f;

    void Update()
    {
        if (Vector2.Distance(player.position, enemy.position) <= interactionDistance)
        {
            button.SetActive(true);
        }
        else
        {
            button.SetActive(false);
        }
    }
}
