using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// guthub rep https://github.com/Jice128/BomberHammer2D.git

/*  �������� 
 *  1. �������� ����������� 
 *  2. ��������� ������������� ������  V
 *  2.2 ���������� ���� ������� ����� ������� �����  V
 *  3. ������� �������/���������� � �� (�������������� �������� � ������ 2.2 ��� ���������� ����� ���������)
 *  4. ���������� ��� 2� �������. (�� ����� ������, � �� ����)
 *  5. ������ ������
 *  */
public class BombScriptP2 : MonoBehaviour
{
    //public ShootScript ShootScript;
    public float coundownTimer = 2.6f;
    private void Start()
    {
        
    }
    void Update()
    {
     
        coundownTimer -= Time.deltaTime;
        if (coundownTimer <= 0f)
        { //���  Brackey ����������� ������������ Singleton, � �� �������
          //FindObjectOfType<MapDestroyerScript>().Explode(transform.position);
           
            GameObject.Find("Grid").GetComponent<MapDestroyerScriptP2>().Explode(transform.position);

            Destroy(gameObject);     
        }




    }

    private void OnTriggerExit2D(Collider2D collision)
    {
      // ����� "������ �� �����" � ��� ������ �����
        GetComponent<CircleCollider2D>().isTrigger = false;
    }






}
