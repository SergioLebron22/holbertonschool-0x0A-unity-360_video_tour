using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HotspotHandler : MonoBehaviour
{
    public Button livingRoomBtn;
    public Button cantinaBtn;
    public Button cubeBtn;
    public Button mezzanineBtn;

    public GameObject livingRoom;
    public GameObject cube;
    public GameObject cantina;
    public GameObject mezzanine;

    public Canvas fadeCanvas;
    public Image fadeImage;

    private GameObject currentActiveHotspot;

    public void Start()
    {
        currentActiveHotspot = livingRoom;
        currentActiveHotspot.SetActive(true);

        cube.SetActive(false);
        cantina.SetActive(false);
        mezzanine.SetActive(false);

    }

    private IEnumerator SmoothSwitchHotspot(GameObject newHotspot) {
        yield return StartCoroutine(FadeOut(2.5f));

        if (currentActiveHotspot != null) {
            currentActiveHotspot.SetActive(false);
        }
        currentActiveHotspot = newHotspot;
        currentActiveHotspot.SetActive(true);

        yield return StartCoroutine(FadeIn(2.5f));
    }
    
    public IEnumerator FadeIn(float duration) {
        Color startAlpha = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 1);
        Color targetAlpha = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 0);

        yield return Fade(startAlpha, targetAlpha, duration);
        fadeCanvas.gameObject.SetActive(false);
    }

    public IEnumerator FadeOut(float duration) {
        Color startAlpha = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 0);
        Color targetAlpha = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 1);

        fadeCanvas.gameObject.SetActive(true);
        yield return Fade(startAlpha, targetAlpha, duration);
    }

    private IEnumerator Fade(Color startAlpha, Color targetAlpha, float duration)
    {
        float elapsedTime = 0f;
        float elapsedPercentage = 0;

        while (elapsedPercentage < 1) {
            elapsedPercentage = elapsedTime / duration;
            fadeImage.color = Color.Lerp(startAlpha, targetAlpha, elapsedPercentage);

            yield return null;
            elapsedTime += Time.deltaTime;
        }    
    }

    public void ToLivingRoom()
    {
        StartCoroutine(SmoothSwitchHotspot(livingRoom));
    }

    public void ToCantina()
    {
        StartCoroutine(SmoothSwitchHotspot(cantina));
    }

    public void ToCube()
    {
        StartCoroutine(SmoothSwitchHotspot(cube));
    }

    public void ToMezzanine()
    {
        StartCoroutine(SmoothSwitchHotspot(mezzanine));
    }
}
