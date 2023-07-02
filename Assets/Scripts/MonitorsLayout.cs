using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonitorsLayout : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 1f;
    [SerializeField] private float smoothingSpeed = 5f;
    
    private new RectTransform transform;
    private Vector2 targetPosition;



    private void Start()
    {
        transform = GetComponent<RectTransform>();
        targetPosition = transform.anchoredPosition;
    }

    private void Update()
    {
        var input = 0f;
        if (Input.GetKey(KeyCode.W))
            input += -1;
        if (Input.GetKey(KeyCode.S))
            input += 1;

        targetPosition += Vector2.up * input;

        transform.anchoredPosition = Vector2.Lerp(transform.anchoredPosition, targetPosition, Time.deltaTime * smoothingSpeed);
    }
}
