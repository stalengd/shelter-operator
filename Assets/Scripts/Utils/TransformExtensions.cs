using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TransformExtensions
{
    public static Transform ModifyPosition(this Transform transform, System.Func<Vector3, Vector3> func)
    {
        var position = transform.position;
        transform.position = func(position);
        return transform;
    }

    public static Transform ModifyLocalScale(this Transform transform, System.Func<Vector3, Vector3> func)
    {
        var scale = transform.localScale;
        transform.localScale = func(scale);
        return transform;
    }
}