using UnityEngine;
using System;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get => FindObjectOfType<GameManager>(); }

    private bool GameStarted { get; set; }
    private float GameSpeed { get; set; } = 6.0f;
    public float Score { get; set; }
    private Player Player { get; set; }


    private Obstacle[] Obstacles { get; set; }
    private Transform ObstacleParent { get; set; }


    public static Action OnHandlePulled { get; set; } = delegate { };
    public static Action<float> OnGameFinsihed { get; set; } = delegate { };

    private void Awake()
    {
        Player = Resources.Load<Player>("player");

        Obstacles = Resources.LoadAll<Obstacle>("Obstacles");
        ObstacleParent = GameObject.Find("Environment").transform;
    }

    private void Update()
    {
        if(!GameStarted)
        {
            return;
        }

        Score += GameSpeed * Time.deltaTime;
    }

    public void RestartGame()
    {
        Score = 0;

        Instantiate(Player, GameObject.Find("Environment").transform).transform.position = new Vector2(0, -3.47f);

        StartCoroutine(nameof(Spawning));
        GameStarted = true;
    }

    public void GameOver()
    {
        OnGameFinsihed?.Invoke(Score);
        DeleteAllObstacles();

        StopCoroutine(nameof(Spawning));
        GameStarted = false;
    }

    public void ExitToMenu()
    {
        Destroy(FindObjectOfType<Player>().gameObject);
        DeleteAllObstacles();

        StopCoroutine(nameof(Spawning));
        GameStarted = false;
    }

    private void DeleteAllObstacles()
    {
        Obstacle[] obstacles = FindObjectsOfType<Obstacle>();
        foreach (Obstacle ob in obstacles)
        {
            Destroy(ob.gameObject);
        }
    }

    private IEnumerator Spawning()
    {
        float delay = 3.5f;

        while(true)
        {
            Vector2 position = new Vector2(UnityEngine.Random.Range(-1.83f, 1.83f), 7.0f);
            Quaternion rotation = Quaternion.Euler(Vector3.forward * UnityEngine.Random.Range(0.0f, 360.0f));

            Instantiate(Obstacles[UnityEngine.Random.Range(0, Obstacles.Length)], position, rotation, ObstacleParent);
            yield return new WaitForSeconds(delay);
        }
    }
}