using UnityEngine;

public class Enemy : MonoBehaviour
{
    private const float speed = 1.52f;

    private void Start()
    {
        Vector2 toPlayer = FindObjectOfType<Player>().transform.position - transform.position;
        transform.up = toPlayer;

        Destroy(gameObject, 25.0f);
    }

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.up);
    }
}
