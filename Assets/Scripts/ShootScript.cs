using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
// guthub rep https://github.com/Jice128/BomberHammer2D.git

public class ShootScript : MonoBehaviour
{
    // 2021.11.04 наконец оно более менее играбельно. можно начинать сундук делать..
    [SerializeField]
    public float _bompPlaceRate = 3.0f;
    private float _canIPlace = 0.0f;

    public GameObject usuallBomb;
    public Tilemap JiceBombTilemap;
    public int fireRate = 2;
    public List<GameObject> inventory;
    public GameObject panel;
    public GameObject Player1lost;



    void Start()
    {
        
    }

 
    void Update()
    {
        
       if ((Input.GetKeyDown(KeyCode.E) ) && Time.time > _canIPlace)
        {  
            SettingBombs();
        }
        if (GameObject.Find("Grid").GetComponent<MapDestroyerScript>()._DidBombExplode == true)
        {
          // Debug.Log("был взрыв!");
           GameObject.Find("Grid").GetComponent<MapDestroyerScript>()._DidBombExplode = false;
           inventory.Add(usuallBomb);
        } 
    }



    void SettingBombs()
    {
        if (!(inventory.Count == 0)) //проверка что в инвентаре есть хоть 1 бомба
        {
            _canIPlace = Time.time + _bompPlaceRate;
            Vector3Int cellPosition = JiceBombTilemap.WorldToCell(new Vector3(transform.position.x, transform.position.y, transform.position.z));
            Vector3 cellMid = JiceBombTilemap.GetCellCenterWorld(cellPosition);
            Instantiate(inventory[0], cellMid, Quaternion.identity);
            inventory.RemoveAt(0);
        }
    }

    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "explosion_0(Clone)")
        {
            panel.SetActive(true);
            Player1lost.SetActive(true);
            yield return new WaitForSeconds(0.3f);
            Time.timeScale = 0;
        }
            // Debug.Log("»грок 1 коснулс€ огн€! ѕроиграл!");
            // Destroy(gameObject);
        }
}
