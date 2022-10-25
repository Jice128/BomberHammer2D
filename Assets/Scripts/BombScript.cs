using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// guthub rep https://github.com/Jice128/BomberHammer2D.git

/*  добавить 
 *  1. анимацию перемещения 
 *  2. рандомное возникновение ящиков  V
 *  2.2 количество бомб которые может ставить игрок  V
 *  3. бустеры монетки/ускорители и тд (соответственно вернутся к пункту 2.2 где количество будет увеличено)
 *  4. управление для 2х игроков. (на одном экране, и по сети)
 *  5. таймер уровня
 *  */
public class BombScript : MonoBehaviour
{
  //  public ShootScript ShootScript;
    public float coundownTimer = 2.6f;
 
    void Update()
    {
     
        coundownTimer -= Time.deltaTime;
        if (coundownTimer <= 0f)
        { //тут  Brackey рекомендует использовать Singleton, а не поиском
          //FindObjectOfType<MapDestroyerScript>().Explode(transform.position);
           
            GameObject.Find("Grid").GetComponent<MapDestroyerScript>().Explode(transform.position);

            Destroy(gameObject);     
        }
    }




    private void OnTriggerExit2D(Collider2D collision)
    {
        // после "выхода из бомбы" в нее нельзя войти
        GetComponent<CircleCollider2D>().isTrigger = false;
    }

}
