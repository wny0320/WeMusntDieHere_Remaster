using System.Collections.Generic;
using UnityEngine;

public class MapJsonData
{
    public bool[,] map;
    public List<Maps> MapList = new List<Maps>();
    public List<Vector2Int> EscapeCandidate = new List<Vector2Int>();

    public Vector2Int playerPos = Vector2Int.one;
}
