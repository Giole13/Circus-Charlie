using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireHoopController : MonoBehaviour
{
    private RectTransform fireHoopObjRect = default;

    public float backGroundMoveSpeed = 1f;

    //후프 속도
    private float moveSpeed = 0;

    private ObstaclesPoolingController parentScript = default;

    private bool isSyncMoveLeft = false;
    private bool isSyncMoveRight = false;

    //// 왼쪽 bool 동기화
    //public void SyncMoveLeft(ref bool SyncLeft)
    //{
    //    isSyncMoveLeft = SyncLeft;
    //}

    //// 오른쪽 bool 동기화
    //public void SyncMoveRight(ref bool SyncRight)
    //{
    //    isSyncMoveRight = SyncRight;
    //}


    // Start is called before the first frame update
    void Start()
    {
        // 움직이는 속도
        moveSpeed = transform.parent.GetComponent<ObstaclesPoolingController>().
            hoopSpeed;

        // 자신의 렉트 트랜스폼
        fireHoopObjRect = GetComponent<RectTransform>();

        fireHoopObjRect.anchoredPosition = Vector2.right * 800f;

        parentScript = transform.parent.GetComponent<ObstaclesPoolingController>();

        backGroundMoveSpeed = parentScript.hoopMoveSpeed;
        

    }

    // Update is called once per frame
    void Update()
    {
        //isSyncMoveLeft = parentScript.isSyncMoveLeft;
        //isSyncMoveRight = parentScript.isSyncMoveRight;
        // 왼쪽 방향키를 눌렀을 때
        //if (isSyncMoveLeft)
        //{
        //    fireHoopObjRect.anchoredPosition += Vector2.left * moveSpeed * Time.deltaTime * backGroundMoveSpeed;
        //    Debug.Log("Dasdf");
        //}
        //else // 그렇지 않았을 때
        //{
        //    // 후프의 가속도를 가하는 로직
        //    fireHoopObjRect.anchoredPosition += Vector2.left * moveSpeed * Time.deltaTime;
        //}

        //// 오른쪽 방향키를 눌렀을 때
        //if (isSyncMoveRight)
        //{
        //    fireHoopObjRect.anchoredPosition -= Vector2.left * moveSpeed * Time.deltaTime * backGroundMoveSpeed;
        //}
        //else // 그렇지 않았을 때
        //{
        //    // 후프의 가속도를 가하는 로직
        //}

        fireHoopObjRect.anchoredPosition += Vector2.left * moveSpeed * Time.deltaTime;

        // 후프의 위치를 초기화하고 꺼주는 로직
        // 자신의 렉트 트랜스폼X의 위치가 
        if (fireHoopObjRect.anchoredPosition.x < -800f)
        {

            fireHoopObjRect.anchoredPosition = Vector2.right * 800f;

            // 플레이어 렉트 트랜스폼 가져와서 그 위치에 +준 자리에 초기화

            gameObject.SetActive(false);
        }
    }


    //public void MoveHoopleft()
    //{
    //    fireHoopObjRect.anchoredPosition += Vector2.right * Time.deltaTime * backGroundMoveSpeed;
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            PlayerController player = collision.transform.GetComponent<PlayerController>();
            player.Die();
        }
    }



}
