using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class DebugTools
{
    public static string TableToString(int cellWidth, IEnumerable<IEnumerable<string>> table, char separator = '|')
    {
        var str = new StringBuilder();

        foreach (var row in table)
        {
            var colIndex = 0;
            foreach (var col in row)
            {
                str.Append(col);
                str.Append(' ', Mathf.Max(cellWidth - col.Length, 0));
                str.Append(' ');
                str.Append(separator);
                str.Append(' ');
                colIndex++;
            }
            str.AppendLine();
        }

        return str.ToString();
    }
}