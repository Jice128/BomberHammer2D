using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class ShootScriptP2 : MonoBehaviour
{
    [SerializeField]
    public float _bompPlaceRate = 3.0f;
    private float _canIPlace = 0.0f;
    public GameObject usuallBomb;
    public Tilemap JiceBombTilemap;
    public int fireRate = 2;
    public List<GameObject> inventory;
    public GameObject panel;
    public GameObject Player2lost;
  


    void Start()
    {

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad9) && Time.time > _canIPlace)
        {
                       SettingBombs();
        }
            
        if (GameObject.Find("Grid").GetComponent<MapDestroyerScriptP2>()._DidBombExplode == true)
        {
            // Debug.Log("был взрыв!");
            GameObject.Find("Grid").GetComponent<MapDestroyerScriptP2>()._DidBombExplode = false;
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
        if (collision.gameObject.name == "explosion_0(Clone)") {
            //  GameObject.Find("GameManager").GetComponent<Game_Manager_Script>().GameOverP2();
            panel.SetActive(true);
            Player2lost.SetActive(true);
            //  panel.GetComponent<Game_Manager_Script>().GameOverP2();
            yield return new WaitForSeconds(0.3f);
            Time.timeScale = 0;
    }
        //  Debug.Log("Игрок 2 коснулся огня! проиграл!");
        // Destroy(gameObject);
    }
}
