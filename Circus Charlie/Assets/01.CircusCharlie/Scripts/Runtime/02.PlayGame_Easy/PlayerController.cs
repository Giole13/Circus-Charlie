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

    //! ���� ����� �� ���� ����
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGroundTouch = true;
        playerAnimator.SetBool("Ground", isGroundTouch);
    }

    //! ������ �������� ���� ���� �Ұ���
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGroundTouch = false;
        playerAnimator.SetBool("Ground", isGroundTouch);
    }

    //! �÷��̾ �״� �Լ�
    public void Die()
    {
        gameOver = true;
        //playerRigid2D.velocity = Vector2.zero;
        Debug.Log("����߽��ϴ�!");
        Time.timeScale = 0f;
        playerAnimator.SetBool("Die", true);

    }

    // ���𰡿� �浹���� ��
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.transform.tag == "BackGround")
        //{
        //    //Debug.Log("���� ��׶���!");

        //}

        if (collision.transform.tag == "Obstacle")
        {
            Die();
        }
    }


    // istrigger�� �浹���� ��
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "ScoreBox")
        {
            // ���� ����!
            currentScore += 100;

            ScoreNumObj.SetTmpText($"{currentScore}");
            Debug.Log("������ �����Ǿ����ϴ�!");

        }
    }

    //private void OnCollisionStay(Collision collision)
    //{
    //    if (collision.transform.tag == "Goal")
    //    {
    //        // ���⼭ ���� ���������� �Ѿ�� ���� ¥�ֱ�
    //        Debug.Log("�� �����ؽ��! ");

    //        playerAnimator.SetBool("PlayerGoal", true);
    //        //playerAnimator.SetBool("Ground", isGroundTouch);
    //    }
    //}

}
