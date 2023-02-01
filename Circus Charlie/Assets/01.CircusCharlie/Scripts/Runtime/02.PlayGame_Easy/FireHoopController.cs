using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireHoopController : BgpoolScrollingController
{
    private RectTransform fireHoopObjRect = default;
    private RectTransform playerRectTransform = default;
    private RectTransform parentFireHoopObjRect = default;

    public float backGroundMoveSpeed = 10f;

    private const string PLAYER_OBJ_NAME = "Player";
    private const string MAIN_OBJ_NAME = "MainObjs";

    //후프 속도
    private float moveSpeed = 0;

    // Start is called before the first frame update
    void Start()
    {
        // 움직이는 속도
        moveSpeed = transform.parent.GetComponent<ObstaclesPoolingController>().
            hoopSpeed;
        
        fireHoopObjRect = GetComponent<RectTransform>();



        parentFireHoopObjRect = gameObject.transform.parent.
            GetComponent<RectTransform>();

        fireHoopObjRect.anchoredPosition = Vector2.right * 800f;
    }

    // Update is called once per frame
    void Update()
    {
        // 후프의 가속도를 가하는 로직
        fireHoopObjRect.anchoredPosition += Vector2.left * moveSpeed * Time.deltaTime;

        //if (backGroundLeft || Input.GetKey(KeyCode.A))
        //{
        //    fireHoopObjRect.anchoredPosition += Vector2.right * Time.deltaTime * backGroundMoveSpeed;
        //}
        //else if (backGroundRight || Input.GetKey(KeyCode.D))
        //{
        //    fireHoopObjRect.anchoredPosition += Vector2.left * Time.deltaTime * backGroundMoveSpeed;
        //}






        // 후프의 위치를 초기화하고 꺼주는 로직
        if (fireHoopObjRect.anchoredPosition.x < -800f)
        {
            playerRectTransform.anchoredPosition = parentFireHoopObjRect.anchoredPosition +
                (Vector2.right * 800f);
            // 플레이어 렉트 트랜스폼 가져와서 그 위치에 +준 자리에 초기화

            gameObject.SetActive(false);
        }
    }


    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.transform.tag == "Player")
    //    {
    //        PlayerController player = collision.transform.GetComponent<PlayerController>();
    //        player.Die();
    //    }
    //}

}
