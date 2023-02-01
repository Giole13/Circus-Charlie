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

}
