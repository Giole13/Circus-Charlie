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
                    // BG_Pool�� 
                    playerObjRect.anchoredPosition += Vector2.left * Time.deltaTime * backGroundMoveSpeed;
                }
                else
                {
                    // ����� �����̴� ���� ( ����
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
                    // BG_Pool�� 
                    playerObjRect.anchoredPosition += Vector2.right * Time.deltaTime * backGroundMoveSpeed;
                }
                else
                {
                    // ����� �����̴� ���� ( ������
                    backGroundPool.anchoredPosition += Vector2.left * Time.deltaTime * backGroundMoveSpeed;
                    //obstaclesRect.anchoredPosition -= Vector2.left * Time.deltaTime * backGroundMoveSpeed;
                }
            }
        }       // if: ���� ��������� �� �۵�
        else
        {
            //if (backGroundLeft) // ���ʹ���Ű�� ���� �����
            //{
            //    backGroundPool.anchoredPosition += Vector2.right * Time.deltaTime * backGroundMoveSpeed;
            //}
            //else if (backGroundLeft == false)
            //{
            //�⺻�� �ڷ� ���ִ°ɷ� �����ϰ� 
            //backGroundPool.anchoredPosition += Vector2.left * Time.deltaTime * backGroundMoveSpeed;
            //}
            backGroundPool.anchoredPosition += Vector2.left * Time.deltaTime * backGroundMoveSpeed;

        }



    }

    //! ���� ����Ű ������ ��
    public void KeyDownLeft()
    {
        backGroundLeft = true;
    }

    //! ���� ����Ű ������ ��
    public void KeyUPLeft()
    {
        backGroundLeft = false;
    }

    //! ������ ����Ű ������ ��
    public void KeyDownRight()
    {
        backGroundRight = true;
    }

    //! ������ ����Ű ������ ��
    public void KeyUPRight()
    {
        backGroundRight = false;
    }

    // ���� bool ����ȭ
    public void SyncMoveLeft(ref bool SyncLeft)
    {
        SyncLeft = backGroundLeft;
    }

    // ������ bool ����ȭ
    public void SyncMoveRight(ref bool SyncRight)
    {
        SyncRight = backGroundRight;
    }

}
