using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public static class LinqExtensions
{
    public static T Min<T>(this IEnumerable<T> collection, Func<T, float> selector)
    {
        T minObject = default;
        float minValue = float.MaxValue;

        foreach (var item in collection)
        {
            var v = selector(item);
            if (v < minValue)
            {
                minValue = v;
                minObject = item;
            }
        }

        return minObject;
    }

    public static T Max<T>(this IEnumerable<T> collection, Func<T, float> selector)
    {
        T minObject = default;
        float maxValue = float.MinValue;

        foreach (var item in collection)
        {
            var v = selector(item);
            if (v > maxValue)
            {
                maxValue = v;
                minObject = item;
            }
        }

        return minObject;
    }

    public static T Random<T>(this IEnumerable<T> collection)
    {
        return collection.ElementAt(UnityEngine.Random.Range(0, collection.Count()));
    }

    public static int IndexOf<T>(this IEnumerable<T> collection, T targetItem)
    {
        if (targetItem == null)
            return -1;

        int i = 0;
        foreach (var item in collection)
        {
            if (targetItem.Equals(item))
                return i;
            i++;
        }
        return -1;
    }

    public static int IndexOf<T>(this IEnumerable<T> collection, Predicate<T> predicate)
    {
        int i = 0;
        foreach (var item in collection)
        {
            if (predicate(item))
                return i;
            i++;
        }
        return -1;
    }

    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
    {
        return source.Shuffle(new Random());
    }

    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random rng)
    {
        if (source == null) throw new ArgumentNullException("source");
        if (rng == null) throw new ArgumentNullException("rng");

        return source.ShuffleIterator(rng);
    }

    private static IEnumerable<T> ShuffleIterator<T>(
        this IEnumerable<T> source, Random rng)
    {
        var buffer = source.ToList();
        for (int i = 0; i < buffer.Count; i++)
        {
            int j = rng.Next(i, buffer.Count);
            yield return buffer[j];

            buffer[j] = buffer[i];
        }
    }
}