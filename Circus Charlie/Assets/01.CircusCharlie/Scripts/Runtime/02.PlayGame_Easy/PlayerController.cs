using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRigid2D = default;
    public float jumpPower = 300f;
    private float playerSpeed = 500f;

    public bool gameOver = false;

    public bool isGroundTouch = false;


    private GameObject ScoreNumObj = default;
    private RectTransform playerRect = default;
    private bool backGroundLeft = false;
    private bool backGroundRight = false;

    private int currentScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerRigid2D = gameObject.GetComponent<Rigidbody2D>();
        playerRect = gameObject.GetComponent<RectTransform>();
        //_playerRigid2D.AddForce(new Vector2(0, 1000));

        ScoreNumObj = GioleFunc.GetRootObj("UIObjs").FindChildObj("ScoreNum");
        Debug.Log(ScoreNumObj.name);
        currentScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnClickJump();
        }

        
    }


    public void OnClickJump()
    {
        if (isGroundTouch)
        {
            playerRigid2D.AddForce(new Vector2(0, jumpPower));
        }



    }

    //! 땅에 닿았을 때 점프 가능
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGroundTouch = true;
    }

    //! 땅에서 떨어졌을 때는 점프 불가능
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGroundTouch = false;
    }

    //! 플레이어가 죽는 함수
    public void Die()
    {
        gameOver = true;
        //playerRigid2D.velocity = Vector2.zero;
        Debug.Log("사망했습니다!");
        Time.timeScale = 0f;
    }

    // 무언가와 충돌했을 때
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "BackGround")
        {
            //Debug.Log("여긴 백그라운드!");

        }

        if (collision.transform.tag == "Obstacle")
        {
            Die();
        }
    }


    // istrigger와 충돌했을 때
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "ScoreBox")
        {
            // 점수 증가!
            currentScore += 100;
            ScoreNumObj.SetTmpText($"{currentScore}");
            Debug.Log("점수가 증가되었습니다!");

        }
    }


    ////! 왼쪽 방향키 눌렀을 때
    //public void KeyDownLeft()
    //{
    //    backGroundLeft = true;
    //}

    ////! 왼쪽 방향키 놓았을 때
    //public void KeyUPLeft()
    //{
    //    backGroundLeft = false;
    //}

    ////! 오른쪽 방향키 눌렀을 때
    //public void KeyDownRight()
    //{
    //    backGroundRight = true;
    //}

    ////! 오른쪽 방향키 놓았을 때
    //public void KeyUPRight()
    //{
    //    backGroundRight = false;
    //}


}
