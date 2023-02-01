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
            // ����� �����̴� ���� ( ����
            backGroundPool.anchoredPosition += Vector2.right * Time.deltaTime * backGroundMoveSpeed;
            //obstaclesRect.anchoredPosition -= Vector2.right * Time.deltaTime * backGroundMoveSpeed;
            //Debug.Log(obstaclesRect.anchoredPosition);
        }
        else if (backGroundRight || Input.GetKey(KeyCode.D))
        {
            // ����� �����̴� ���� ( ������
            backGroundPool.anchoredPosition += Vector2.left * Time.deltaTime * backGroundMoveSpeed;
            //obstaclesRect.anchoredPosition -= Vector2.left * Time.deltaTime * backGroundMoveSpeed;

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
