using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadingPanel : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    private Tween fadeTween;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(TestFade());
    }


    public void FadeIn(float duration)
    {
        Fade(1f, duration, () =>
        {
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        });
    }


    public void FaidOut(float duration)
    {
        Fade(0f, duration, () =>
        {
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        });
    }

    private void Fade(float endValue,float duration,TweenCallback Onend)
    {
        if( fadeTween !=null )
        {
            fadeTween.Kill(false);
        }

        fadeTween = canvasGroup.DOFade(endValue,duration);
        fadeTween.onComplete += Onend;
        
    }

    private IEnumerator TestFade()
    {
        yield return new WaitForSeconds(2f); 
        FaidOut(1f);
        yield return new WaitForSeconds(3f);
        FadeIn (1f);
    }
}
