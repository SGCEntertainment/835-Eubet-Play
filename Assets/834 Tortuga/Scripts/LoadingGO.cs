using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class LoadingGO : MonoBehaviour
{
    Transform spinner;
    const float rotSpinnerSpeed = 650.0f;

    public static Action OnLoadingStarted { get; set; } = delegate { };
    public static Action OnLoadingFinished { get; set; } = delegate { };

    private IEnumerator Start()
    {
        OnLoadingStarted?.Invoke();

        spinner = GameObject.Find("spinner").transform;

        float et = 0.0f;
        float loadingTime = Random.Range(1.5f, 2.0f);

        while(et < loadingTime)
        {
            spinner.Rotate(rotSpinnerSpeed * Time.deltaTime * Vector3.back);

            et += Time.deltaTime;
            yield return null;
        }

        gameObject.SetActive(false);
        OnLoadingFinished?.Invoke();
    }
}
