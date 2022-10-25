using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CoinScript : MonoBehaviour
{

 //   public Tilemap tile_mapForDestroyCoins;
    private int CoinsLife = 2;
    // Start is called before the first frame update
    void Start()
    {
  //      tile_mapForDestroyCoins = GameObject.Find("Tilemap_gameplay").GetComponent<Tilemap>();
  
    }

    // Update is called once per frame
    void Update() {

     

        CoinDeath(CoinsLife);  //может конечно не очень оптимально но пока сойдет.

    }


    void CoinDeath(int lifetoleft)
    {
         if (lifetoleft == 0)
            Destroy(gameObject);
    }


     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player2")
        {
          //  Debug.Log("игрок2 взял монетку");
            GameObject.Find("Player2").GetComponent<ShootScriptP2>().fireRate++;
            Destroy(gameObject);
          
        }

        if (other.gameObject.name == "Player1")
        {
            //Debug.Log("игрок1 взял монетку");
            GameObject.Find("Player1").GetComponent<ShootScript>().fireRate++;
            Destroy(gameObject);
           
            //

        }

        if (other.gameObject.name == "explosion_0(Clone)")
        {
            //первый огонь который разрушает ящик не "убивает" монетку. второй убьет.
            CoinsLife--;
        }

       
        //определить какой из игроков взял монетку
        //усилить его на 1 ячейку огня
    }
}
