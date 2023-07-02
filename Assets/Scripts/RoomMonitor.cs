using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomMonitor : MonoBehaviour
{
    [SerializeField] private RawImage cameraImage;
    [SerializeField] private RectTransform nameBadge;
    [SerializeField] private float nameBadgeRotationRange = 10f;

    private Room Room => Rooms.RoomsList[transform.GetSiblingIndex()];


    private void Start()
    {
        nameBadge.localRotation = Quaternion.Euler(0f, 0f, Random.Range(-nameBadgeRotationRange, nameBadgeRotationRange));

        var outputRect = cameraImage.rectTransform.rect;
        var outputSize = new Vector2Int(Mathf.RoundToInt(outputRect.width), Mathf.RoundToInt(outputRect.height));
        cameraImage.texture = Room.CreateCameraTexture(outputSize);
    }
}