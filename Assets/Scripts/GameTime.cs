using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameTime : SingletonMonoBehaviour<GameTime>
{
    [SerializeField] private TMP_Text timeText;

    public static System.TimeSpan TimeFromStart { get; private set; }


    private void Update()
    {
        TimeFromStart = TimeFromStart.Add(System.TimeSpan.FromSeconds(Time.deltaTime));
        timeText.text = TimeFromStart.ToString("mm\\:ss");
    }
}
