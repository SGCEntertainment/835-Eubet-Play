using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private GameObject _last;

    [SerializeField] GameObject howToPlay;
    [SerializeField] GameObject game;

    [Space(10)]
    [SerializeField] Text scoreText;

    private void Awake()
    {
        LoadingGO.OnLoadingStarted += () =>
        {
            howToPlay.SetActive(false);
            game.SetActive(false);
        };

        LoadingGO.OnLoadingFinished += () =>
        {
            howToPlay.SetActive(true);
            howToPlay.GetComponentInChildren<Button>().onClick.AddListener(() =>
            {
                OpenWindow(1);
                GameManager.Instance.RestartGame();
            });
        };

        GameManager.OnGameFinsihed += (score) =>
        {
            Instantiate(Resources.Load<Popup>("popup"), GameObject.Find("screen").transform).SetData(Mathf.FloorToInt(score), () =>
            {
                GameManager.Instance.RestartGame();
            });
        };

        _last = howToPlay;
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
            case 0: _last = howToPlay; break;
            case 1: _last = game; break;
        }

        _last.SetActive(true);
    }
}