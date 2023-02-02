using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMaker : MonoBehaviour
{
    private GameObject backGround = default;
    private GameObject allBG = default;

    private const string BACK_GROUND_NAME = "AllBackGround";
    private const string MAIN_OBJ_NAME = "MainObjs";

    // Start is called before the first frame update
    void Start()
    {
        // ȭ�� �ػ� ��������
        GameObject MainObjs = GioleFunc.GetRootObj(MAIN_OBJ_NAME);

        // ������ ������Ʈ ��������
        backGround = GioleFunc.FindChildObj(gameObject, BACK_GROUND_NAME);

        // ȭ�� �ػ� ������ ��������
        //Vector2 mainObjsTransform = MainObjs.GetRectSizeDelta();
        Vector2 mainObjsRectTransform = MainObjs.GetRectSizeDelta();

        float backGroundPositionX = 0f;

        int remainingMeter = 10;

        // ���� 10�� ����� ����
        for (int i = 0; i < 10; ++i)
        {
            allBG = Instantiate(backGround, gameObject.transform);
            if(i == 0 || i == 9)
            {
                allBG.GetComponent<BoxCollider2D>().enabled = true;
                if(i == 0)
                {
                    allBG.FindChildObj("FireJar").SetActive(false);
                }
            }

            allBG.FindChildObj("RemainingMeters").SetTmpText($"{remainingMeter}0 M");
            allBG.name = backGround.name + i;
            allBG.SetLocalPos(backGroundPositionX, 0, 0);

            backGroundPositionX += mainObjsRectTransform.x;
            --remainingMeter;
        }


        // ���� ������ �ҷ��ͼ� ��ġ�����ִ� ����
        // ����ٰ� ������ ���̶�� �ڽ� �ݶ��̴� �߰� ����
        GameObject prefab = Resources.Load<GameObject>("Prefabs/GoalStage");
        GameObject goalStage = Instantiate(prefab, allBG.transform);
        goalStage.SetLocalPos(350f, -170f, 0);
        




        backGround.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
