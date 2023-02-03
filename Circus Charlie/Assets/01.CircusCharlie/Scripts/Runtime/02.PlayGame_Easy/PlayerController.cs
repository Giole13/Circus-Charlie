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
    private GameObject BestNumObj = default;

    private RectTransform playerRect = default;
    private bool backGroundLeft = false;
    private bool backGroundRight = false;

    private int currentScore = 0;
    private int bestScore = 0;

    private Animator playerAnimator = default;

    // Start is called before the first frame update
    void Start()
    {
        playerRigid2D = gameObject.GetComponent<Rigidbody2D>();
        playerRect = gameObject.GetComponent<RectTransform>();
        //_playerRigid2D.AddForce(new Vector2(0, 1000));

        ScoreNumObj = GioleFunc.GetRootObj("UIObjs").FindChildObj("CurrentScore").
            FindChildObj("ScoreNum");
        BestNumObj = GioleFunc.GetRootObj("UIObjs").FindChildObj("HighScore").
            FindChildObj("ScoreNum");
        Debug.Log(ScoreNumObj.name);
        playerAnimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        bestScore = PlayerPrefs.GetInt("BestScore");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnClickJump();
        }


        if (bestScore <= currentScore)
        {
            bestScore = currentScore;
            PlayerPrefs.SetInt("BestScore", bestScore);
        }


        BestNumObj.SetTmpText($"{bestScore}");

    }


    public void OnClickJump()
    {
        if (isGroundTouch)
        {
            playerRigid2D.AddForce(new Vector2(0, jumpPower));
        }

        if (gameOver)
        {
            GioleFunc.LoadScene(GioleData.PLAY_SCENE_NAME);
            Time.timeScale = 1f;
        }
    }

    //! 땅에 닿았을 때 점프 가능
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGroundTouch = true;
        playerAnimator.SetBool("Ground", isGroundTouch);
    }

    //! 땅에서 떨어졌을 때는 점프 불가능
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGroundTouch = false;
        playerAnimator.SetBool("Ground", isGroundTouch);
    }

    //! 플레이어가 죽는 함수
    public void Die()
    {
        gameOver = true;
        //playerRigid2D.velocity = Vector2.zero;
        Debug.Log("사망했습니다!");
        Time.timeScale = 0f;
        playerAnimator.SetBool("Die", true);

    }

    // 무언가와 충돌했을 때
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.transform.tag == "BackGround")
        //{
        //    //Debug.Log("여긴 백그라운드!");

        //}

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

    //private void OnCollisionStay(Collision collision)
    //{
    //    if (collision.transform.tag == "Goal")
    //    {
    //        // 여기서 다음 스태이지로 넘어가는 구문 짜주기
    //        Debug.Log("오 도착해썽요! ");

    //        playerAnimator.SetBool("PlayerGoal", true);
    //        //playerAnimator.SetBool("Ground", isGroundTouch);
    //    }
    //}

}
