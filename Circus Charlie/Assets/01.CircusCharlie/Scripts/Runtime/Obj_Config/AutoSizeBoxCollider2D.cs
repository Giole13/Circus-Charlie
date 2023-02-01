using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSizeBoxCollider2D : MonoBehaviour
{

    public bool isUseParentSize = false;

    // BoxCollider2D�� ũ�⸦ �ڵ����� RectTransformũ��� �����ִ� ��ũ��Ʈ
    void Start()
    {
        Vector2 thisSize = default;

        // �ڽ��� ��Ʈ ������
        RectTransform thisRect = GetComponent<RectTransform>();
        // �θ��� ��Ʈ������
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
