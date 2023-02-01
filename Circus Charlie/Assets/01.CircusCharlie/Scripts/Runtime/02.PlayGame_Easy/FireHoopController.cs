using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireHoopController : MonoBehaviour
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

        // �ڽ��� ��Ʈ Ʈ������
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


        // ������ ��ġ�� �ʱ�ȭ�ϰ� ���ִ� ����
        // �ڽ��� ��Ʈ Ʈ������X�� ��ġ�� 
        if (fireHoopObjRect.anchoredPosition.x < -800f)
        {

            //fireHoopObjRect.anchoredPosition =
            //    playerRectTransform.anchoredPosition + (Vector2.right * 800f);
            //playerRectTransform.anchoredPosition = parentFireHoopObjRect.anchoredPosition +
            //    (Vector2.right * 800f);
            fireHoopObjRect.anchoredPosition = Vector2.right * 800f;

            // �÷��̾� ��Ʈ Ʈ������ �����ͼ� �� ��ġ�� +�� �ڸ��� �ʱ�ȭ

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
