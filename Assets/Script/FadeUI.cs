using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeUI : MonoBehaviour {

    public static FadeUI instance;

    public bool isFadeIn = false;
    public bool fadeTrigger = false;
    float fadeSpeed = 4;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        FadeIn();
        isFadeIn = true;
    }

    private void Update()
    {
        if (fadeTrigger)
        {
            Debug.Log("fade in and out");
            StartCoroutine(DoFadeOutandIn());
            fadeTrigger = false;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("fade test");
            if (!isFadeIn)
            {
                FadeIn();
                isFadeIn = true;
            }
            else
            {
                FadeOut();
                isFadeIn = false;
            }
        }
    }

    public void FadeOut()
    {
        StartCoroutine(DoFadeOut());
    }

    public void FadeOutFast()
    {
        StartCoroutine(DoFadeOutFast());
    }

    public void FadeInFast()
    {
        StartCoroutine(DoFadeInFast());
    }

    private IEnumerator DoFadeOutFast()
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        while (canvasGroup.alpha < 1)
        {
            //canvasGroup.alpha += Time.deltaTime * fadeSpeed * fadeSpeed;
            canvasGroup.alpha = 1;
            yield return null;
        }
        isFadeIn = false;
        yield return null;
    }

    private IEnumerator DoFadeInFast()
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        while (canvasGroup.alpha > 0)
        {
            //canvasGroup.alpha -= Time.deltaTime * fadeSpeed * fadeSpeed;
            canvasGroup.alpha = 0;
            yield return null;
        }
        isFadeIn = true;
        yield return null;
    }

    public void FadeIn()
    {
        StartCoroutine(DoFadeIn());
    }

    IEnumerator DoFadeOut()
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += Time.deltaTime * fadeSpeed;
            yield return null;
        }
        isFadeIn = false;
        yield return null;

    }

    IEnumerator DoFadeIn()
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime * fadeSpeed;
            yield return null;
        }
        isFadeIn = true;
        yield return null;

    }

    IEnumerator DoFadeOutandIn()
    {
        yield return StartCoroutine(DoFadeOut());

        yield return StartCoroutine(DoFadeIn());

        yield return null;

    }

}
