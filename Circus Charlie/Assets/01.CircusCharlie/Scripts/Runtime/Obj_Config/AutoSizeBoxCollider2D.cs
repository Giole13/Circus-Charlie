using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSizeBoxCollider2D : MonoBehaviour
{

    public bool isUseParentSize = false;

    // BoxCollider2D의 크기를 자동으로 RectTransform크기로 맞춰주는 스크립트
    void Start()
    {
        Vector2 thisSize = default;

        // 자신의 렉트 사이즈
        RectTransform thisRect = GetComponent<RectTransform>();
        // 부모의 렉트사이즈
        RectTransform parentRect = transform.parent.gameObject.
            GetComponent<RectTransform>();

        BoxCollider2D thisCollider2D = GetComponent<BoxCollider2D>();


        if (isUseParentSize)
        {
            thisSize.x = parentRect.sizeDelta.x;
            thisSize.y = parentRect.sizeDelta.y;
        }
        else
        {
            thisSize.x = thisRect.sizeDelta.x;
            thisSize.y = thisRect.sizeDelta.y;
        }

        thisCollider2D.size = thisSize;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
