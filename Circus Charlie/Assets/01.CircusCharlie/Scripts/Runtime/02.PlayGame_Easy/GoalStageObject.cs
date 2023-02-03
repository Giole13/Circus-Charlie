using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalStageObject : MonoBehaviour
{


    private Animator playerAnimator = default;

    // Start is called before the first frame update
    void Start()
    {
        GameObject main = GioleFunc.GetRootObj(GioleData.MAIN_OBJ_NAME);

        GameObject playerObj = main.FindChildObj(GioleData.PLAYER_OBJ_NAME);

        playerAnimator = playerObj.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            // 여기서 다음 스태이지로 넘어가는 구문 짜주기
            Debug.Log("오 도착해썽요! ");

            playerAnimator.SetBool("PlayerGoal", true);
            //playerAnimator.SetBool("Ground", isGroundTouch);
        }
        
    }

}
