using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombcountBoostScript : MonoBehaviour
{

    private int CoinsLife = 2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CoinDeath(CoinsLife);
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
          //  Debug.Log("игрок2 увеличил количество бомб");
            //   GameObject.Find("Player2").GetComponent<ShootScriptP2>().fireRate++;
            GameObject.Find("Player2").GetComponent<ShootScriptP2>()._bompPlaceRate = 0.07f;
           GameObject.Find("Player2").GetComponent<ShootScriptP2>().inventory.Add(GameObject.Find("Player2").GetComponent<ShootScriptP2>().usuallBomb);
            Destroy(gameObject);
        }

        if (other.gameObject.name == "Player1")
        {
          //  Debug.Log("игрок1 увеличил количество бомб");
            GameObject.Find("Player1").GetComponent<ShootScript>()._bompPlaceRate = 0.07f;
            GameObject.Find("Player1").GetComponent<ShootScript>().inventory.Add(GameObject.Find("Player1").GetComponent<ShootScript>().usuallBomb);
            Destroy(gameObject);
        }

        if (other.gameObject.name == "explosion_0(Clone)")
        {
            //первый огонь который разрушает ящик не "убивает" монетку. второй убьет.
            CoinsLife--;
        }
    }
}
