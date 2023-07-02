using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    [SerializeField] private float maxCalmness = 10f;
    [SerializeField] private float maxCalmnessRandomizer = 5f;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float runningSpeedMultiplier = 2f;
    [SerializeField] private float randomSpeedMultiplierRange = 0.1f;
    [SerializeField] private new SpriteRenderer renderer;
    [SerializeField] private Animator animator;

    [Header("Cosmetics")]
    [SerializeField] private SpriteRenderer faceRenderer;
    [SerializeField] private Sprite[] faces;

    [Space]
    [SerializeField] private SpriteRenderer frontHairRenderer;
    [SerializeField] private SpriteRenderer backHairRenderer;
    [SerializeField] private Hair[] hairVariants;

    private bool IsArrived => Mathf.Abs(transform.position.x - targetPosition) <= 0.1f;
    private float SpeedMultiplier => (targetRoom == null ? 1f : runningSpeedMultiplier) * randomSpeedMultiplier;

    private Room targetRoom;
    private bool isInQueue;

    private float calmness = 1f;
    private float randomSpeedMultiplier = 1f;
    private float targetPosition;


    [System.Serializable]
    public struct Hair
    {
        public Sprite frontSprite;
        public Sprite backSprite;
        public Gradient colorVariants;
    }


    private void Start()
    {
        RefillCalmness();
        randomSpeedMultiplier = 1f + Random.Range(-randomSpeedMultiplierRange, randomSpeedMultiplierRange);
        faceRenderer.sprite = faces.Random();

        var hairs = hairVariants.Random();
        var hairColor = hairs.colorVariants.Evaluate(Random.value);
        frontHairRenderer.sprite = hairs.frontSprite;
        frontHairRenderer.color = hairColor;
        backHairRenderer.sprite = hairs.backSprite;
        backHairRenderer.color = hairColor;
    }

    private void Update()
    {
        if (calmness > 0)
        {
            calmness -= Time.deltaTime;
            GameManager.AddHpFromUpdate();

            if (IsArrived)
            {
                targetPosition = Random.Range(-10f, 10f);
            }
        }
        else
        {
            if (targetRoom == null) 
            {
                targetRoom = Rooms.RoomsList.Random();
                targetPosition = targetRoom.GetRandomPosition();
            }


            if (IsArrived && !isInQueue)
            {
                targetRoom.AppendToQuery(this);
                isInQueue = true;
            }
            if (isInQueue)
                GameManager.ReduceHpFromUpdate();
        }

        if (!IsArrived)
        {
            var dir = Mathf.Sign(targetPosition - transform.position.x);
            transform.position += dir * speed * SpeedMultiplier * Time.deltaTime * Vector3.right;
            transform.ModifyLocalScale(s => s.WithX(-dir));
        }

        animator.SetBool("IsWalking", !IsArrived);
        animator.SetFloat("SpeedMultiplier", SpeedMultiplier);
    }


    public void OnFulfill()
    {
        targetRoom = null;
        RefillCalmness();
        isInQueue = false;
    }

    private void RefillCalmness()
    {
        calmness = maxCalmness + Random.Range(-maxCalmnessRandomizer / 2f, maxCalmnessRandomizer / 2f);
    }
}