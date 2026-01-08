using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapGenerator : MonoBehaviour
{
    [Header("Map Size")]
    public int width = 16;
    public int height = 10;

    [Header("Tilemaps (drag from Hierarchy)")]
    public Tilemap groundMap;
    public Tilemap wallMap;

    private TileBase groundTile;
    private TileBase wallTile;

    private void Awake()
    {
        CreateTiles();
        GenerateMap();
    }

    private void CreateTiles()
    {
        // Ground tile (visual)
        Tile ground = ScriptableObject.CreateInstance<Tile>();
        ground.color = new Color(0.6f, 0.6f, 0.6f);
        groundTile = ground;

        // Wall tile (visual; collision comes from Walls tilemap collider)
        Tile wall = ScriptableObject.CreateInstance<Tile>();
        wall.color = new Color(0.3f, 0.3f, 0.3f);
        wallTile = wall;
    }

    private void GenerateMap()
    {
        if (groundMap == null || wallMap == null)
        {
            Debug.LogError("TilemapGenerator: Assign Ground Map and Wall Map in the Inspector.");
            return;
        }

        groundMap.ClearAllTiles();
        wallMap.ClearAllTiles();

        int halfW = width / 2;
        int halfH = height / 2;

        int minX = -halfW;
        int maxX = halfW - 1;
        int minY = -halfH;
        int maxY = halfH - 1;

        for (int x = minX; x <= maxX; x++)
        {
            for (int y = minY; y <= maxY; y++)
            {
                Vector3Int pos = new Vector3Int(x, y, 0);

                bool border = (x == minX) || (x == maxX) || (y == minY) || (y == maxY);

                if (border)
                    wallMap.SetTile(pos, wallTile);
                else
                    groundMap.SetTile(pos, groundTile);
            }
        }
    }
}
