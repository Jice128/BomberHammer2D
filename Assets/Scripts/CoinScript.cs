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

     

        CoinDeath(CoinsLife);  //����� ������� �� ����� ���������� �� ���� ������.

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
          //  Debug.Log("�����2 ���� �������");
            GameObject.Find("Player2").GetComponent<ShootScriptP2>().fireRate++;
            Destroy(gameObject);
          
        }

        if (other.gameObject.name == "Player1")
        {
            //Debug.Log("�����1 ���� �������");
            GameObject.Find("Player1").GetComponent<ShootScript>().fireRate++;
            Destroy(gameObject);
           
            //

        }

        if (other.gameObject.name == "explosion_0(Clone)")
        {
            //������ ����� ������� ��������� ���� �� "�������" �������. ������ �����.
            CoinsLife--;
        }

       
        //���������� ����� �� ������� ���� �������
        //������� ��� �� 1 ������ ����
    }
}
