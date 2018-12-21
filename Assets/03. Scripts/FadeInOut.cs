using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour {

    public Image image;
    public Color black;
    public Color transparent;
    public float _duration;

    public AudioSource breathSound;

    public void OnFadeInButtonClick()
    {
        StartCoroutine(FadeIn(_duration));
    }

    public void OnFadeOutButtonClick()
    {
        breathSound.Play();
        StartCoroutine(FadeOut(_duration));
    }

    IEnumerator FadeOut(float duration)
    {
        float timer = 0;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            image.color = new Color(0,0,0, (timer / duration));
            yield return null;
        }
    }

    IEnumerator FadeIn(float duration)
    {
        float timer = 0;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            image.color = new Color(0, 0, 0, 1f - (timer / duration));
            yield return null;
        }
    }

}
