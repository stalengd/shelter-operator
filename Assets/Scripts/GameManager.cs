using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    [SerializeField] private float maxHp = 100f;
    [SerializeField] private float passiveHpSupply = 0.1f;
    [SerializeField] private float successHpSupply = 5f;
    [SerializeField] private float failHpPenalty = 5f;

    [Space]
    [SerializeField] private int startHumansCount = 5;
    [SerializeField] private GameObject humanPrefab;
    [SerializeField] private Transform humansSpawnPoint;
    [SerializeField] private Vector2 humansSpawnRange;

    [Space]
    [SerializeField] private Image hpBar;
    [SerializeField] private TMP_Text humansCountText;

    private float HP
    {
        get => hp;
        set
        {
            hp = value;
            hp = Mathf.Clamp(hp, 0f, maxHp);
            hpBar.fillAmount = hp / maxHp;
        }
    }

    private int HumansCount
    {
        get => humansCount;
        set
        {
            humansCount = value;
            humansCountText.text = humansCount.ToString();
        }
    }

    private float hp;
    private int lastCheckMinute = 0;
    private int humansCount;


    private void Start()
    {
        HP = maxHp;
        HumansCount = startHumansCount;
    }

    private void Update()
    {
        if (GameTime.TimeFromStart.Minutes != lastCheckMinute)
        {
            lastCheckMinute = GameTime.TimeFromStart.Minutes;

            SpawnHuman();
        }
    }


    public static void ReduceHpFromUpdate()
    {
        Instance.HP -= Time.deltaTime;
    }

    public static void AddHpFromUpdate()
    {
        Instance.HP += Instance.passiveHpSupply * Time.deltaTime;
    }

    public static void AddHpBySuccess()
    {
        Instance.HP += Instance.successHpSupply;
    }

    public static void ReduceHpByFail()
    {
        Instance.HP -= Instance.failHpPenalty;
    }


    private Human SpawnHuman()
    {
        var randomOffset = new Vector3(Random.Range(-humansSpawnRange.x, humansSpawnRange.x), Random.Range(-humansSpawnRange.y, humansSpawnRange.y));
        var human = Instantiate(humanPrefab, humansSpawnPoint.position + randomOffset, Quaternion.identity).GetComponent<Human>();

        HumansCount++;

        return human;
    }
}