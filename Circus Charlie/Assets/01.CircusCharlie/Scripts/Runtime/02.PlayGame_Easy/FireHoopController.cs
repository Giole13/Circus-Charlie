using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// �� �� ��Ʈ�ѷ�
public class FireHoopController : MonoBehaviour
{
    private RectTransform fireHoopObjRect = default;

    public float backGroundMoveSpeed = 1f;

    private float bgPoolpositionAbsoluteFloat = 0f;

    //���� �ӵ�
    //private float moveSpeed = 0f;

    private BgpoolScrollingController parentScript = default;

    private RectTransform parentObjRect = default;

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
        //moveSpeed = transform.parent.GetComponent<BgpoolScrollingController>().
        //    backGroundMoveSpeed;

        // �ڽ��� ��Ʈ Ʈ������
        fireHoopObjRect = GetComponent<RectTransform>();

        parentObjRect = gameObject.gameObject.transform.parent.
            GetComponent<RectTransform>();

        //fireHoopObjRect.anchoredPosition = Vector2.right * 800f;
    }

    // Update is called once per frame
    void Update()
    {
        bgPoolpositionAbsoluteFloat =
            Mathf.Abs(parentObjRect.anchoredPosition.x) - 800f;

        fireHoopObjRect.anchoredPosition += Vector2.left * 300f * Time.deltaTime;

        // ������ ��ġ�� �ʱ�ȭ�ϰ� ���ִ� ����
        // �ڽ��� ��Ʈ Ʈ������X�� ��ġ�� 
        //if (fireHoopObjRect.anchoredPosition.x < -800f)
        if (fireHoopObjRect.anchoredPosition.x < bgPoolpositionAbsoluteFloat)
        {
            gameObject.SetActive(false);
        }
    }



}
