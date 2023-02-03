using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalStageObject : MonoBehaviour
{


    private Animator playerAnimator = default;

    private GameObject playerObj = default;
    public GameObject bg_Pool = default;

    // Start is called before the first frame update
    void Start()
    {
        GameObject main = GioleFunc.GetRootObj(GioleData.MAIN_OBJ_NAME);

        playerObj = main.FindChildObj(GioleData.PLAYER_OBJ_NAME);

        //bg_Pool = main.transform.Find(GioleData.BGPOOL_OBJ_NAME).gameObject;

        //Debug.Log(bg_Pool + "���̿���");

        playerAnimator = playerObj.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            // ���⼭ ���� ���������� �Ѿ�� ���� ¥�ֱ�
            Debug.Log("�� �����ؽ��! ");

            playerAnimator.SetBool("PlayerGoal", true);

            //playerObj.GetComponent<PlayerController>().enabled = false;
            //bg_Pool.GetComponent<BgpoolScrollingController>().enabled = false;
            //collision.transform.gameObject.GetComponent<PlayerController>().enabled = false;



            //playerAnimator.SetBool("Ground", isGroundTouch);


        }

    }

}
