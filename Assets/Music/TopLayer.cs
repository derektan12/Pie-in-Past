using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopLayer : MonoBehaviour
{
    private AudioSource audioSource;
    const float FADE_TIME = 1;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0f;
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate()
    {
        print("fdsaf");
        StartCoroutine(FadeIn());
    }

    public void DeActivate()
    {
       StartCoroutine(FadeOut());
    }
    IEnumerator FadeOut()
    {
        float timeElapsed = 0;

        while (audioSource.volume > 0)
        {
            audioSource.volume = Mathf.Lerp(1, 0, timeElapsed / FADE_TIME);
            timeElapsed += Time.deltaTime;
            yield return "";
        }
    }

    IEnumerator FadeIn()
    {
        float timeElapsed = 0;

        while (audioSource.volume < 1)
        {
            audioSource.volume = Mathf.Lerp(0, 1, timeElapsed / FADE_TIME);
            timeElapsed += Time.deltaTime;
            yield return "";
        }
    }
}
