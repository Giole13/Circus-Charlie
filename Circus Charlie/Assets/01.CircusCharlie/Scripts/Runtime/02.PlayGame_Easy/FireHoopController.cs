using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireHoopController : MonoBehaviour
{
    private RectTransform fireHoopObjRect = default;

    public float backGroundMoveSpeed = 1f;

    //���� �ӵ�
    private float moveSpeed = 0;

    private ObstaclesPoolingController parentScript = default;

    private bool isSyncMoveLeft = false;
    private bool isSyncMoveRight = false;

    //// ���� bool ����ȭ
    //public void SyncMoveLeft(ref bool SyncLeft)
    //{
    //    isSyncMoveLeft = SyncLeft;
    //}

    //// ������ bool ����ȭ
    //public void SyncMoveRight(ref bool SyncRight)
    //{
    //    isSyncMoveRight = SyncRight;
    //}


    // Start is called before the first frame update
    void Start()
    {
        // �����̴� �ӵ�
        moveSpeed = transform.parent.GetComponent<ObstaclesPoolingController>().
            hoopSpeed;

        // �ڽ��� ��Ʈ Ʈ������
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
        // ���� ����Ű�� ������ ��
        //if (isSyncMoveLeft)
        //{
        //    fireHoopObjRect.anchoredPosition += Vector2.left * moveSpeed * Time.deltaTime * backGroundMoveSpeed;
        //    Debug.Log("Dasdf");
        //}
        //else // �׷��� �ʾ��� ��
        //{
        //    // ������ ���ӵ��� ���ϴ� ����
        //    fireHoopObjRect.anchoredPosition += Vector2.left * moveSpeed * Time.deltaTime;
        //}

        //// ������ ����Ű�� ������ ��
        //if (isSyncMoveRight)
        //{
        //    fireHoopObjRect.anchoredPosition -= Vector2.left * moveSpeed * Time.deltaTime * backGroundMoveSpeed;
        //}
        //else // �׷��� �ʾ��� ��
        //{
        //    // ������ ���ӵ��� ���ϴ� ����
        //}

        fireHoopObjRect.anchoredPosition += Vector2.left * moveSpeed * Time.deltaTime;

        // ������ ��ġ�� �ʱ�ȭ�ϰ� ���ִ� ����
        // �ڽ��� ��Ʈ Ʈ������X�� ��ġ�� 
        if (fireHoopObjRect.anchoredPosition.x < -800f)
        {

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
