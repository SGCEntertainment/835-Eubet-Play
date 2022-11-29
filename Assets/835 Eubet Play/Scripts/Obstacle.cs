using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private const float speed = 0.76f;

    private void Start()
    {
        Destroy(gameObject, 25.0f);
    }

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.down, Space.World);
    }
}
