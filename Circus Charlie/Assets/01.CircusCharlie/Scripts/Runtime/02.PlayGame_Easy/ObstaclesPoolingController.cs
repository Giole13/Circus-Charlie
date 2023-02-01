using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesPoolingController : MonoBehaviour
{
    public float hoopSpeed = 1f;
    public float hoopCreateTime = 3f;
    public float hoopMoveSpeed = 1f;

    public List<GameObject> hoopPoolList = default;

    private float createTime = 0;

    private RectTransform ObstaclesRect = default;
    private const string SHORT_HOOP_NAME = "FireHoopShort";
    private const string LONG_HOOP_NAME = "FireHoopLong";

    private BgpoolScrollingController bgPoolObjScript = default;

    public bool isSyncMoveLeft = false;
    public bool isSyncMoveRight = false;

    // Start is called before the first frame update
    void Start()
    {
        // ������Ʈ Ǯ���� ģ���� ��������
        GameObject shortHoopObj = GioleFunc.FindChildObj(gameObject, SHORT_HOOP_NAME);
        GameObject longHoopObj = GioleFunc.FindChildObj(gameObject, LONG_HOOP_NAME);
        ObstaclesRect = gameObject.GetComponent<RectTransform>();

        //bgPoolObjScript = GioleFunc.GetRootObj(GioleData.MAIN_OBJ_NAME).FindChildObj(GioleData.BGPOOL_OBJ_NAME).
        //    GetComponent<BgpoolScrollingController>();
            
        //hoopMoveSpeed = GioleFunc.GetRootObj(GioleData.MAIN_OBJ_NAME).FindChildObj(GioleData.BGPOOL_OBJ_NAME).
        //    GetComponent<BgpoolScrollingController>().backGroundMoveSpeed;

        // �ν��Ͻ� �ؼ� Ǯ���ٰ� �־��ֱ�!
        for (int i = 0; i < 3; ++i)
        {
            Debug.Log("�ν���Ƽ����Ʈ");
            GameObject shorthoop_ = Instantiate(shortHoopObj, gameObject.transform);
            shorthoop_.name = SHORT_HOOP_NAME + "_" + i;
            hoopPoolList.Add(shorthoop_);
            shorthoop_.SetActive(false);
        }
        for (int i = 3; i < 6; ++i)
        {
            GameObject longhoop_ = Instantiate(longHoopObj, gameObject.transform);
            longhoop_.name = LONG_HOOP_NAME + "_" + i;
            hoopPoolList.Add(longhoop_);
            longhoop_.SetActive(false);
        }

        shortHoopObj.SetActive(false);
        longHoopObj.SetActive(false);

        //bgPoolObjScript.SyncMoveLeft(ref isSyncMoveLeft);
        //bgPoolObjScript.SyncMoveRight(ref isSyncMoveRight);
    }

    // Update is called once per frame
    void Update()
    {
        ObstaclesRect.anchoredPosition = Vector2.zero;
        createTime += Time.deltaTime;

        // �������� �ð����� ������ ���ִ� �Լ�
        if (hoopCreateTime < createTime)
        {
            int i = Random.RandomRange(0, 6);

            hoopPoolList[i].SetActive(true);

            createTime = 0f;
        }

        
    }
}
