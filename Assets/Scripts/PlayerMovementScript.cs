using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// guthub rep https://github.com/Jice128/BomberHammer2D.git
public class PlayerMovementScript : MonoBehaviour
{

    /*  �������� 
 *  1. �������� �����������
 *  2. ��������� ������������� ������ V
 *  2.2 ���������� ���� ������� ����� ������� �����  
 *  3. ������� �������/���������� � ��
 *  4. ���������� ��� 2� �������. (�� ����� ������, � �� ����) ���...
 *  5. ������ ������
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
       // Debug.Log("����� �� �����");
       Player1Animator.SetBool("IsJumping", false);
    }

    private void FixedUpdate()
    {
        NashController.Move(HorizontalMove * Time.fixedDeltaTime, false, JumpButton);
        JumpButton = false;
        
    }

}
