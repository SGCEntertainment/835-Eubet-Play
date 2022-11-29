using UnityEngine;

public class Enemy : MonoBehaviour
{
    private const float speed = 1.52f;
    private Transform Target { get; set; }

    private void Awake()
    {
        Target = FindObjectOfType<Player>().transform;
    }

    private void Start()
    {
        InvokeRepeating(nameof(UpdateDirection), 0.0f, 4.0f);
        Destroy(gameObject, 25.0f);
    }

    private void UpdateDirection()
    {
        if(transform.position.y <= -2.8f)
        {
            return;
        }

        Vector2 toPlayer = Target.position - transform.position;
        transform.up = toPlayer;
    }

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.up);
    }
}
