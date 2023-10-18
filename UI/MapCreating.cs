using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapCreating : MonoBehaviour
{
    [SerializeField] private TileBase sprite;

    private Tilemap tilemap;

    private void Awake()
    {
        tilemap = GetComponent<Tilemap>();
    }

    void Start()
    {
       tilemap.SetTile(new TileChangeData(Vector3Int.zero, sprite, Color.white, Matrix4x4.identity), true);
    }
}
