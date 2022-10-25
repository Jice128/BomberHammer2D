
using UnityEngine;
using UnityEngine.Tilemaps;
// guthub rep https://github.com/Jice128/BomberHammer2D.git
public class BombSpawnerJiceScript : MonoBehaviour
{
    public Tilemap jiceTilemap;
    public GameObject bombPrefab;

    // Update is called once per frame
    void Update()
    {
       /* if (Input.GetMouseButtonDown(0))
        {
            Vector3 WorldPositionMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int cellPosition = jiceTilemap.WorldToCell(WorldPositionMouse);
            Vector3 cellMid = jiceTilemap.GetCellCenterWorld(cellPosition);

            Instantiate(bombPrefab, cellMid, Quaternion.identity);
        }*/
    }
}
