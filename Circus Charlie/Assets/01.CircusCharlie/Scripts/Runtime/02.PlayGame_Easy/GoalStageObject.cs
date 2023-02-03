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

        //Debug.Log(bg_Pool + "여이여이");

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
            // 여기서 다음 스태이지로 넘어가는 구문 짜주기
            Debug.Log("오 도착해썽요! ");

            playerAnimator.SetBool("PlayerGoal", true);

            //playerObj.GetComponent<PlayerController>().enabled = false;
            //bg_Pool.GetComponent<BgpoolScrollingController>().enabled = false;
            //collision.transform.gameObject.GetComponent<PlayerController>().enabled = false;



            //playerAnimator.SetBool("Ground", isGroundTouch);


        }

    }

}
