using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgpoolScrollingController : MonoBehaviour
{
    public float backGroundMoveSpeed = 10f;

    protected bool backGroundLeft = false;
    protected bool backGroundRight = false;
    private RectTransform backGroundPool = default;
    private RectTransform obstaclesRect = default;

    private GameObject obstacles = default;
    

    // Start is called before the first frame update
    void Start()
    {
        GameObject main = GioleFunc.GetRootObj(GioleData.MAIN_OBJ_NAME);
        obstacles = main.FindChildObj(GioleData.OBSTACLES_OBJ_NAME);

        obstaclesRect = obstacles.GetRect();
        backGroundPool = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {

        if (backGroundLeft || Input.GetKey(KeyCode.A))
        {
            // 배경을 움직이는 로직 ( 왼쪽
            backGroundPool.anchoredPosition += Vector2.right * Time.deltaTime * backGroundMoveSpeed;
            //obstaclesRect.anchoredPosition -= Vector2.right * Time.deltaTime * backGroundMoveSpeed;
            //Debug.Log(obstaclesRect.anchoredPosition);
        }
        else if (backGroundRight || Input.GetKey(KeyCode.D))
        {
            // 배경을 움직이는 로직 ( 오른쪽
            backGroundPool.anchoredPosition += Vector2.left * Time.deltaTime * backGroundMoveSpeed;
            //obstaclesRect.anchoredPosition -= Vector2.left * Time.deltaTime * backGroundMoveSpeed;

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
