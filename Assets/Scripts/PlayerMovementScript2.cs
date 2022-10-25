using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// guthub rep https://github.com/Jice128/BomberHammer2D.git
public class PlayerMovementScript2 : MonoBehaviour
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
    public Animator Player2Animator;


    // Update is called once per frame
    void Update()
    {
        HorizontalMove = Input.GetAxisRaw("HorizontalP2") * RunSpeed;

        Player2Animator.SetFloat("Speed", Mathf.Abs(HorizontalMove));

        if (Input.GetButtonDown("Jump2"))
        {
            JumpButton = true;
          //  Player2Animator.SetBool("IsJumping", true);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
    }

    private void FixedUpdate()
    {
        NashController.Move(HorizontalMove * Time.fixedDeltaTime, false, JumpButton);
        JumpButton = false;
    }

}
