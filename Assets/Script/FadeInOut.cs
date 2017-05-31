using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut : MonoBehaviour {

    public Texture2D fadeTexture;
    float fadeSpeed = 1f;
    int drawDepth = -1000;

    float alpha = 1.0f;
    int fadeInDir = -1;
    int fadeOutDir = 1;

    [SerializeField]bool isBlack = true;
    PlayerController p;


	// Use this for initialization
	void Start () {
        //fadeTexture = new Texture2D()
    }

    private void LateUpdate()
    {
        if (p == null)
        {
            p = GameObject.FindObjectOfType<PlayerController>();
        }
    }
    // Update is called once per frame
    void Update () {
        
    }

    //private void OnGUI()
    //{
    //    if (isBlack && p.fadeTrigger)
    //    {
    //        Debug.Log("fade in");
    //        StartCoroutine(FadeIn());
    //        StartCoroutine(Wait());
    //        //p.fadeTrigger = false;
    //    }
    //    else if(!isBlack && p.fadeTrigger)
    //    {
    //        Debug.Log("fade out");
    //        StartCoroutine(FadeOut());
    //        //p.fadeTrigger = false;
    //    }
    //}

    IEnumerator FadeIn()
    {
        alpha += fadeInDir * fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);

        yield return null;

        if (alpha < 0.001)//매직넘버 고쳐야함
        {
            //isBlack = false;
            p.fadeTrigger = false;
        }

        yield break;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
        if (isBlack)
        {
            isBlack = false;
        }
        else isBlack = true;

        yield break;
    }

    IEnumerator FadeOut()
    {
        alpha += fadeOutDir * fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);

        yield return null;

        if (alpha > 0.999)//공포의 매직넘버
        {
            //isBlack = true;
            p.fadeTrigger = false;
        }

        yield break;

    }

}
