using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgpoolScrollingController : MonoBehaviour
{
    public float backGroundMoveSpeed = 10f;

    private bool backGroundLeft = false;
    private bool backGroundRight = false;
    private RectTransform backGroundPool = default;

    // Start is called before the first frame update
    void Start()
    {
        backGroundPool = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {

        if (backGroundLeft)
        {
            backGroundPool.anchoredPosition += Vector2.right * Time.deltaTime * backGroundMoveSpeed;
        }
        else if (backGroundRight)
        {
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

}
