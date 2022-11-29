using UnityEngine;

public class Ground : MonoBehaviour
{
    private Material mat;
    [SerializeField] float speed;

    private void Awake()
    {
        mat = GetComponent<SpriteRenderer>().material;
    }

    private void Update()
    {
        mat.mainTextureOffset = speed * Time.time * Vector2.up;
    }
}
