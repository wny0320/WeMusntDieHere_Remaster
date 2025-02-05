using System.Collections.Generic;
using UnityEngine;

public class MapJsonData
{
    public bool[,] map;
    public bool[,] isVisited;
    public MapType[,] mapTypes;
    public List<Vector2Int> EscapeCandidate = new List<Vector2Int>();

    public Vector2Int playerPos = Vector2Int.one;

    public MapJsonData(bool[,] map, bool[,] isVisited, MapType[,] mapTypes, List<Vector2Int> escapeCandidate, Vector2Int playerPos)
    {
        this.map = map;
        this.isVisited = isVisited;
        this.mapTypes = mapTypes;
        EscapeCandidate = escapeCandidate;
        this.playerPos = playerPos;
    }
}
