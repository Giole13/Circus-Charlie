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

    //���� �ӵ�
    private float moveSpeed = 0;

    // Start is called before the first frame update
    void Start()
    {
        // �����̴� �ӵ�
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
        // ������ ���ӵ��� ���ϴ� ����
        fireHoopObjRect.anchoredPosition += Vector2.left * moveSpeed * Time.deltaTime;

        //if (backGroundLeft || Input.GetKey(KeyCode.A))
        //{
        //    fireHoopObjRect.anchoredPosition += Vector2.right * Time.deltaTime * backGroundMoveSpeed;
        //}
        //else if (backGroundRight || Input.GetKey(KeyCode.D))
        //{
        //    fireHoopObjRect.anchoredPosition += Vector2.left * Time.deltaTime * backGroundMoveSpeed;
        //}






        // ������ ��ġ�� �ʱ�ȭ�ϰ� ���ִ� ����
        if (fireHoopObjRect.anchoredPosition.x < -800f)
        {
            playerRectTransform.anchoredPosition = parentFireHoopObjRect.anchoredPosition +
                (Vector2.right * 800f);
            // �÷��̾� ��Ʈ Ʈ������ �����ͼ� �� ��ġ�� +�� �ڸ��� �ʱ�ȭ

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
