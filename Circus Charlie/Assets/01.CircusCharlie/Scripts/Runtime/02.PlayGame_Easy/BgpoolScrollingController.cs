using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgpoolScrollingController : MonoBehaviour
{
    public float backGroundMoveSpeed = 10f;

    protected bool backGroundLeft = false;
    protected bool backGroundRight = false;

    private bool isGroundTouch = true;

    private ObstaclesPoolingController ObstacleScript = default;
    private RectTransform backGroundPool = default;
    private GameObject obstacles = default;
    private RectTransform playerObjRect = default;
    private PlayerController playerScript = default;

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
    }

    // Update is called once per frame
    void Update()
    {
        isGroundTouch = playerScript.isGroundTouch;


        if (isGroundTouch)
        {
            if (backGroundLeft || Input.GetKey(KeyCode.A))
            {
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
            else if (backGroundRight || Input.GetKey(KeyCode.D))
            {
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
        }       // if: 땅에 닿아있을때 만 작동
        else
        {
            //if (backGroundLeft) // 왼쪽방향키를 누른 경우라면
            //{
            //    backGroundPool.anchoredPosition += Vector2.right * Time.deltaTime * backGroundMoveSpeed;
            //}
            //else if (backGroundLeft == false)
            //{
            //기본은 뒤로 가있는걸로 설정하고 
            //backGroundPool.anchoredPosition += Vector2.left * Time.deltaTime * backGroundMoveSpeed;
            //}
            backGroundPool.anchoredPosition += Vector2.left * Time.deltaTime * backGroundMoveSpeed;

        }



    }

    //! 왼쪽 방향키 눌렀을 때
    public void KeyDownLeft()
    {
        backGroundLeft = true;
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
