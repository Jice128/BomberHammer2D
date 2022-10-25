using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// guthub rep https://github.com/Jice128/BomberHammer2D.git
public class PlayerMovementScript : MonoBehaviour
{

    /*  добавить 
 *  1. анимацию перемещения
 *  2. рандомное возникновение ящиков V
 *  2.2 количество бомб которые может ставить игрок  
 *  3. бустеры монетки/ускорители и тд
 *  4. управление для 2х игроков. (на одном экране, и по сети) мля...
 *  5. таймер уровня
 *  */
    public CharacterController2D NashController;
    public float RunSpeed = 40f;
    float HorizontalMove = 0f;
    bool JumpButton = false;
    public Animator Player1Animator;


    // Update is called once per frame
    void Update()
    {
        HorizontalMove = Input.GetAxisRaw("HorizontalP1") * RunSpeed;

        Player1Animator.SetFloat("Speed", Mathf.Abs(HorizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            JumpButton = true;
            Player1Animator.SetBool("IsJumping", true);
        }

    }
   
    public void OnLanding()
    {
       // Debug.Log("игрок на земле");
       Player1Animator.SetBool("IsJumping", false);
    }

    private void FixedUpdate()
    {
        NashController.Move(HorizontalMove * Time.fixedDeltaTime, false, JumpButton);
        JumpButton = false;
        
    }

}
