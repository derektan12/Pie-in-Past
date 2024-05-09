using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BaseMusic : MonoBehaviour
{
    private AudioSource audioSource;
    const float FADE_TIME = 5;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
