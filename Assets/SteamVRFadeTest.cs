using UnityEngine;

public class SteamVRFadeTest : MonoBehaviour
{
    private float _fadeDuration = 2f;

    private void Start()
    {
        //FadeToWhite();
        //Invoke("FadeFromWhite", _fadeDuration);
    }
    private void FadeToWhite()
    {
        //set start color
        SteamVR_Fade.Start(Color.clear, 0f);
        //set and start fade to
        SteamVR_Fade.Start(Color.white, _fadeDuration);
    }
    private void FadeFromWhite()
    {
        //set start color
        SteamVR_Fade.Start(Color.white, 0f);
        //set and start fade to
        SteamVR_Fade.Start(Color.clear, _fadeDuration);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SteamVR_Fade.View(Color.black, 0);
            SteamVR_Fade.View(Color.clear, 1);
        }

    }
}