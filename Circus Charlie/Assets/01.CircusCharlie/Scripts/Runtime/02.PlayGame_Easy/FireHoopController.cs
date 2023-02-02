using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// 불 고리 컨트롤러
public class FireHoopController : MonoBehaviour
{
    private RectTransform fireHoopObjRect = default;

    public float backGroundMoveSpeed = 1f;

    private float bgPoolpositionAbsoluteFloat = 0f;

    //후프 속도
    //private float moveSpeed = 0f;

    private BgpoolScrollingController parentScript = default;

    private RectTransform parentObjRect = default;

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
        //moveSpeed = transform.parent.GetComponent<BgpoolScrollingController>().
        //    backGroundMoveSpeed;

        // 자신의 렉트 트랜스폼
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

        // 후프의 위치를 초기화하고 꺼주는 로직
        // 자신의 렉트 트랜스폼X의 위치가 
        //if (fireHoopObjRect.anchoredPosition.x < -800f)
        if (fireHoopObjRect.anchoredPosition.x < bgPoolpositionAbsoluteFloat)
        {
            gameObject.SetActive(false);
        }
    }



}
