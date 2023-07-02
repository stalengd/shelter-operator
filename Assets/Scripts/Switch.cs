using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Switch : MonoBehaviour
{
    [SerializeField] private Sprite offSprite;
    [SerializeField] private Sprite onSprite;

    [Space]
    [SerializeField] private Image image;
    [SerializeField] private Toggle toggle;

    public bool IsOn
    {
        get => toggle.isOn;
        set
        {
            toggle.isOn = value;
            Refresh();
        }
    }
    public Toggle Toggle => toggle;


    private void Awake()
    {
        toggle.onValueChanged.AddListener(v => Refresh());
        Refresh();
    }

    private void Refresh()
    {
        image.sprite = toggle.isOn ? onSprite : offSprite;
    }
}
