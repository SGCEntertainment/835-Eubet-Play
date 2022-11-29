using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Popup : MonoBehaviour
{
    public void SetData(int score, UnityAction action)
    {
        GameObject.Find("finalScoreText").GetComponent<Text>().text = $"{score}";

        GameObject.Find("again").GetComponent<Button>().onClick.AddListener(action);
        GameObject.Find("again").GetComponent<Button>().onClick.AddListener(() =>
        {
            Destroy(gameObject);
        });
    }
}
