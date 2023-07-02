using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuccessIndicator : MonoBehaviour
{
    [SerializeField] private float flashTime = 0.2f;

    [Space]
    [SerializeField] private Image image;
    [SerializeField] private Sprite successSprite;
    [SerializeField] private Sprite failSprite;
    [SerializeField] private Sprite defaultSprite;

    private Coroutine currentCoroutine;


    public void Success()
    {
        DoEffect(successSprite);
    }

    public void Fail()
    {
        DoEffect(failSprite);
    }

    private void DoEffect(Sprite sprite)
    {
        if (currentCoroutine != null)
            StopCoroutine(currentCoroutine);

        currentCoroutine = StartCoroutine(EffectCoroutine(sprite));
    }

    private IEnumerator EffectCoroutine(Sprite sprite)
    {
        image.sprite = sprite;

        yield return new WaitForSeconds(flashTime);

        image.sprite = defaultSprite;
    }
}