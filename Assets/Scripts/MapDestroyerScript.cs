using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
// guthub rep https://github.com/Jice128/BomberHammer2D.git

public class MapDestroyerScript : MonoBehaviour
{

    public Tilemap tile_map;
    public Tile wallTile;
    public Tile DestructableTile;

    public GameObject ExplosionPrefab;
    public  Vector3 position;
    public bool _DidBombExplode = false;
    public void Explode(Vector2 worldPos)
    {
       Vector3Int origiCellOfExplotion = tile_map.WorldToCell(worldPos);
        //   Debug.Log("ha ha");
        ExplodeCell(origiCellOfExplotion);
        /* if ( ExplodeCell(origiCellOfExplotion + new Vector3Int(1, 0, 0)))
              ExplodeCell(origiCellOfExplotion + new Vector3Int(2, 0, 0));
        временно убрал пока не разобрался как изменить
         if ( ExplodeCell(origiCellOfExplotion + new Vector3Int(0, 1, 0)))
              ExplodeCell(origiCellOfExplotion + new Vector3Int(0, 2, 0));

         if ( ExplodeCell(origiCellOfExplotion + new Vector3Int(-1, 0, 0)))
              ExplodeCell(origiCellOfExplotion + new Vector3Int(-2, 0, 0));

         if ( ExplodeCell(origiCellOfExplotion + new Vector3Int(0, -1, 0)))
              ExplodeCell(origiCellOfExplotion + new Vector3Int(0, -2, 0));
        ExplodeCell(origiCellOfExplotion + new Vector3Int(1, 0, 0));
        ExplodeCell(origiCellOfExplotion + new Vector3Int(0, 1, 0));
        ExplodeCell(origiCellOfExplotion + new Vector3Int(-1, 0, 0));
        ExplodeCell(origiCellOfExplotion + new Vector3Int(0, -1, 0)); */

        for (int i = 0; i < GameObject.Find("Player1").GetComponent<ShootScript>().fireRate; i++)
        {
            if (!ExplodeCell(origiCellOfExplotion + new Vector3Int(i, 0, 0)))
            {
                //  Debug.Log("вроде как НЕ подходящая ячейка");
                break;
            }
        }

        for (int i = 0; i < GameObject.Find("Player1").GetComponent<ShootScript>().fireRate; i++)
        {
            if (!ExplodeCell(origiCellOfExplotion + new Vector3Int(0, i, 0)))
            {
                //  Debug.Log("вроде как НЕ подходящая ячейка");
                break;
            }
        }
        for (int i = 0; i < GameObject.Find("Player1").GetComponent<ShootScript>().fireRate; i++)
        {
            if (!ExplodeCell(origiCellOfExplotion + new Vector3Int(-i, 0, 0)))
            {
                //  Debug.Log("вроде как НЕ подходящая ячейка");
                break;
            }
        }
        for (int i = 0; i < GameObject.Find("Player1").GetComponent<ShootScript>().fireRate; i++)
        {
            if (!ExplodeCell(origiCellOfExplotion + new Vector3Int(0, -i, 0)))
            {
                //  Debug.Log("вроде как НЕ подходящая ячейка");
                break;
            }
        }
    }
        
    bool ExplodeCell (Vector3Int cell)
    {
        Tile tileToExplore = tile_map.GetTile<Tile>(cell);


        Vector3 position = tile_map.GetCellCenterWorld(cell);

        if (tileToExplore == wallTile) //если стена то ничего не делать
            return false;

        if (tileToExplore == DestructableTile)
        {
            //удалить тайл   если там ящик
            tile_map.SetTile(cell, null);

            Instantiate(ExplosionPrefab, position, Quaternion.identity);
            _DidBombExplode = true;
            return false;
        }

        // создать взрыв  cell  

        Instantiate(ExplosionPrefab, position, Quaternion.identity);
        _DidBombExplode = true;

        //если пустота то создать взрыв
        return true;

    }
    /*
     * 
     * B
Fixed problem reported by WolfmanGT123
2 months ago
Boony64
on version 1.9.5
I had the same problem as reported by WolfmanGT123. Managed to get it to build but it's very hacky. 

1) I renamed the RuleTile.cs file in Assembly-CSharp\Assets\2DGameKit\Scripts\Utility to RuleTile2.cs

2) Renamed the class within that file to RuleTile2

3) Changed all references to RuleTile to RuleTile2 in Assembly-CSharp-Editor\Assets\2DGamekit\Utilities\Editor\RuleTileEditor.cs

After that it built and the demo ran fine - which is really impressive.*/


}
