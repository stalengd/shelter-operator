using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room : MonoBehaviour
{
    [SerializeField] private float borderMin;
    [SerializeField] private float borderMax;
    [SerializeField] private new Camera camera;

    public List<Human> HumansQuery { get; } = new List<Human>();



    private void OnDrawGizmosSelected()
    {
        var center = transform.position;
        center.x += (borderMin + borderMax) / 2;
        Gizmos.DrawWireCube(center, new Vector3(borderMax - borderMin, 1f));
    }


    public void AppendToQuery(Human human)
    {
        HumansQuery.Add(human);
    }

    public bool Fulfill()
    {
        if (HumansQuery.Count == 0) return false;

        var human = HumansQuery[0];
        HumansQuery.RemoveAt(0);

        human.OnFulfill();
        return true;
    }


    public float GetRandomPosition()
    {
        return transform.position.x + Random.Range(borderMin, borderMax);
    }

    public RenderTexture CreateCameraTexture(Vector2Int size)
    {
        var tex = new RenderTexture(new RenderTextureDescriptor(Mathf.RoundToInt(size.x), Mathf.RoundToInt(size.y)));
        tex.filterMode = FilterMode.Point;
        camera.targetTexture = tex;
        return tex;
    }
}
