using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgpoolScrollingController : MonoBehaviour
{
    public float backGroundMoveSpeed = 10f;
    public bool isObstaclesFools = false;


    protected bool backGroundLeft = false;
    protected bool backGroundRight = false;

    private bool isGroundTouch = true;

    private ObstaclesPoolingController ObstacleScript = default;
    private RectTransform backGroundPool = default;
    private GameObject obstacles = default;
    private RectTransform playerObjRect = default;
    private PlayerController playerScript = default;

    private Animator playerAnimator = default;

    private bool isleftJump = false;

    // Start is called before the first frame update
    void Start()
    {
        GameObject main = GioleFunc.GetRootObj(GioleData.MAIN_OBJ_NAME);
        obstacles = main.FindChildObj(GioleData.OBSTACLES_OBJ_NAME);
        ObstacleScript = obstacles.GetComponent<ObstaclesPoolingController>();

        backGroundPool = GetComponent<RectTransform>();
        GameObject playerObj = main.FindChildObj(GioleData.PLAYER_OBJ_NAME);
        playerObjRect = playerObj.GetRect();
        playerScript = playerObj.GetComponent<PlayerController>();

        playerAnimator = playerObj.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isGroundTouch = playerScript.isGroundTouch;

        // 배경 전용
        if (isGroundTouch)
        {

            // 왼쪽 키 눌렀을 때
            if (backGroundLeft || Input.GetKey(KeyCode.A))
            {
                playerAnimator.SetBool("backMove", isGroundTouch);

                if (backGroundPool.anchoredPosition.x > 0f || playerObjRect.anchoredPosition.x > -233f)
                {
                    // BG_Pool의 
                    playerObjRect.anchoredPosition += Vector2.left * Time.deltaTime * backGroundMoveSpeed;
                }
                else
                {
                    // 배경을 움직이는 로직 ( 왼쪽
                    backGroundPool.anchoredPosition += Vector2.right * Time.deltaTime * backGroundMoveSpeed;
                    //obstaclesRect.anchoredPosition -= Vector2.right * Time.deltaTime * backGroundMoveSpeed;
                    //Debug.Log(obstaclesRect.anchoredPosition);
                }
            }
            // 오른쪽 키 눌렀을 때
            else if (backGroundRight || Input.GetKey(KeyCode.D))
            {
                playerAnimator.SetBool("Idle", !isGroundTouch);

                if (backGroundPool.anchoredPosition.x < -11511.53f || playerObjRect.anchoredPosition.x < -233f)
                {
                    if (backGroundPool.anchoredPosition.x < -11511.53f) { ObstacleScript.MakerController(); }
                    // BG_Pool의 
                    playerObjRect.anchoredPosition += Vector2.right * Time.deltaTime * backGroundMoveSpeed;
                }
                else
                {
                    // 배경을 움직이는 로직 ( 오른쪽
                    backGroundPool.anchoredPosition += Vector2.left * Time.deltaTime * backGroundMoveSpeed;
                    //obstaclesRect.anchoredPosition -= Vector2.left * Time.deltaTime * backGroundMoveSpeed;
                }
            }
            else
            {
                playerAnimator.SetBool("Idle", true);
                playerAnimator.SetBool("backMove", false);
            }


        }       // if: 땅에 닿아있을때 만 작동
        else
        {       //! 점프할때 적용
            //if (backGroundLeft)
            //{
            //    // BG_Pool의 
            //    playerObjRect.anchoredPosition += Vector2.left * Time.deltaTime * backGroundMoveSpeed;
            //}
            //else if (isleftJump)
            //{
            //    backGroundPool.anchoredPosition += Vector2.right * Time.deltaTime * backGroundMoveSpeed;

            //}
            if (backGroundPool.anchoredPosition.x < -11511.53f || playerObjRect.anchoredPosition.x < -233f)
            {
                // BG_Pool의 
                playerObjRect.anchoredPosition += Vector2.right * Time.deltaTime * backGroundMoveSpeed;
            }
            else
            {
                // 배경을 움직이는 로직 ( 오른쪽
                backGroundPool.anchoredPosition += Vector2.left * Time.deltaTime * backGroundMoveSpeed;
                //obstaclesRect.anchoredPosition -= Vector2.left * Time.deltaTime * backGroundMoveSpeed;
            }

        }


        // 장애물 전용  ( 내 오브젝트 이름이 ObstaclesFools 일 경우
        //if (isObstaclesFools)
        //{
        //    if (backGroundLeft || Input.GetKey(KeyCode.A))
        //    {
        //        backGroundPool.anchoredPosition += Vector2.right * Time.deltaTime * backGroundMoveSpeed;
        //    }
        //    else if (backGroundRight || Input.GetKey(KeyCode.D))
        //    {
        //        backGroundPool.anchoredPosition += Vector2.left * Time.deltaTime * backGroundMoveSpeed;
        //    }
        //}



    }

    //! 왼쪽 방향키 눌렀을 때
    public void KeyDownLeft()
    {
        backGroundLeft = true;
        isleftJump = true;
    }

    //! 왼쪽 방향키 놓았을 때
    public void KeyUPLeft()
    {
        backGroundLeft = false;
    }

    //! 오른쪽 방향키 눌렀을 때
    public void KeyDownRight()
    {
        backGroundRight = true;
    }

    //! 오른쪽 방향키 놓았을 때
    public void KeyUPRight()
    {
        backGroundRight = false;
    }

    // 왼쪽 bool 동기화
    public void SyncMoveLeft(ref bool SyncLeft)
    {
        SyncLeft = backGroundLeft;
    }

    // 오른쪽 bool 동기화
    public void SyncMoveRight(ref bool SyncRight)
    {
        SyncRight = backGroundRight;
    }

}
