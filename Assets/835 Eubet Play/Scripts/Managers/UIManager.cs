using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private GameObject _last;

    [SerializeField] GameObject menu;
    [SerializeField] GameObject scores;
    [SerializeField] GameObject game;

    [Space(10)]
    [SerializeField] Text scoreText;

    private void Awake()
    {
        LoadingGO.OnLoadingStarted += () =>
        {
            menu.SetActive(false);
            scores.SetActive(false);
            game.SetActive(false);
        };

        LoadingGO.OnLoadingFinished += () =>
        {
            menu.SetActive(true);
        };

        GameManager.OnGameFinsihed += (score) =>
        {
            Instantiate(Resources.Load<Popup>("popup"), GameObject.Find("screen").transform).SetData(Mathf.FloorToInt(score), () =>
            {
                GameManager.Instance.RestartGame();
            });
        };

        _last = menu;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && FindObjectOfType<Popup>() == null)
        {
            OpenWindow(0);
            GameManager.Instance.ExitToMenu();
        }

        scoreText.text = $"{Mathf.FloorToInt(GameManager.Instance.Score)}";
    }

    public void OpenWindow(int i)
    {
        if(_last)
        {
            _last.SetActive(false);
        }

        switch(i)
        {
            case 0: _last = menu; break;
            case 1: _last = scores; break;
            case 2: _last = game; break;
        }

        _last.SetActive(true);
        if(i == 2)
        {
            GameManager.Instance.RestartGame();
        }
    }
}